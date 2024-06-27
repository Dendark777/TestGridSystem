using Assets.Scripts;
using Assets.Scripts.Nodes;
using Assets.Scripts.Players;
using Assets.Scripts.StartLevel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChipControl : MonoBehaviour
{
    GridManager gridManager;
    HighLightCell highLghitCells;

    [SerializeField]
    ChipBase selectedChip;
    [SerializeField]
    Node StartNode; //Пока для быстрого спауна

    Pathfinding pathfinding;
    List<PathNode> path;
    private bool movining = false;
    public void Init()
    {
        gridManager = LevelManager.Instance.GridManager;
        highLghitCells = LevelManager.Instance.HighLightCell;

        highLghitCells.Init();
        selectedChip.Init(StartNode);
        pathfinding = new Pathfinding(gridManager);
        Node.OnNodeLeftClicked += ClickOnCellMouseLeft;
        Node.OnNodeRightClicked += ClickOnCellMouseRight;
        ChipBase.OnLeftClicked += ClickOnCharacterMouseLeft;
    }

    private void ClickOnCharacterMouseLeft(GameObject clickedObject)
    {
        if (movining)
        {
            return;
        }
        if (!clickedObject.TryGetComponent<ChipBase>(out selectedChip))
        {
            return;
        }
        var nodeClicked = selectedChip.Node;
        path = null;

        if (!gridManager.CheckPosition(nodeClicked.PosX, nodeClicked.PosY))
        {
            return;
        }

        List<PathNode> toHighlight = new List<PathNode>();
        pathfinding.Clear();
        pathfinding.CalculateWalkableTerrain(selectedChip.Node,
                                             selectedChip.MaxCellMove,
                                             ref toHighlight);
        for (int i = 0; i < toHighlight.Count; i++)
        {
            var pos = toHighlight[i].GetPosition();
            highLghitCells.SetHighLightCell(pos);
        }
    }

    private void ClickOnCellMouseRight(GameObject clickedObject)
    {
        if (movining)
        {
            return;
        }
        var nodeClicked = clickedObject.GetComponent<Node>();
        path = null;

        if (!gridManager.CheckPosition(nodeClicked.PosX, nodeClicked.PosY))
        {
            return;
        }
        if (selectedChip != null)
        {
            List<PathNode> toHighlight = new List<PathNode>();
            pathfinding.Clear();
            pathfinding.CalculateWalkableTerrain(selectedChip.Node,
                                                 selectedChip.MaxCellMove,
                                                 ref toHighlight);
            for (int i = 0; i < toHighlight.Count; i++)
            {
                var pos = toHighlight[i].GetPosition();
                highLghitCells.SetHighLightCell(pos);
            }
        }
    }

    private void ClickOnCellMouseLeft(GameObject clickedObject)
    {
        if (movining)
        {
            return;
        }
        var nodeClicked = clickedObject.GetComponent<Node>();
        if (selectedChip == null)
        {
            selectedChip = nodeClicked.Chip;
            if (selectedChip == null)
            {
                Debug.Log("Не выбран герой");
                return;
            }
        }
        if (path != null)
        {
            StartCoroutine(FollowPath());
            return;
        }
        highLghitCells.ResetAllHighLightCell();
        path = pathfinding.TrackBackPath(nodeClicked.PosX, nodeClicked.PosY);
        if (path != null)
        {
            for (int i = 0; i < path.Count; i++)
            {
                var pos = path[i].GetPosition();
                highLghitCells.SetHighLightCell(pos);
            }
        }
    }

    IEnumerator FollowPath()
    {
        if (selectedChip == null)
        {
            Debug.Log("Не выбран герой");
            yield break;
        }
        if (!path.Any())
        {

            Debug.Log("Нет пути");
            yield break;
        }

        yield return selectedChip.Move(path);

        var node = gridManager.GetNode(path[0].xPos, path[0].yPos);
        selectedChip.Stop(node);
        node.Chip = selectedChip;
        pathfinding.Clear();
        movining = false;
        path = null;
        highLghitCells.ResetAllHighLightCell();
        selectedChip = null;
    }

    void OnDestroy()
    {
        // Отписка от события при уничтожении объекта
        Node.OnNodeLeftClicked -= ClickOnCellMouseLeft;
        Node.OnNodeRightClicked -= ClickOnCellMouseRight;
        ChipBase.OnLeftClicked -= ClickOnCharacterMouseLeft;
    }
}
