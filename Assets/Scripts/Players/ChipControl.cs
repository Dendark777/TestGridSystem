using Assets.Scripts;
using Assets.Scripts.Nodes;
using Assets.Scripts.Players;
using Assets.Scripts.Players.Chip.ChipEvents;
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
    private GridManager _gridManager;
    private HighLightCell _highLghitCells;
    List<ChipBase> _chips;
    [SerializeField]
    ChipBase selectedChip;
    [SerializeField]
    Node StartNode; //Пока для быстрого спауна

    Pathfinding pathfinding;
    List<PathNode> _path;
    private bool movining = false;
    public void Init(List<ChipBase> chips)
    {
        _gridManager = LevelManager.Instance.GridManager;
        _highLghitCells = LevelManager.Instance.HighLightCell;
        _chips = chips;

        _highLghitCells.Init();
        pathfinding = new Pathfinding(_gridManager);
        EventBus.Instance.Subscribe<Node>(ClickOnCellMouseLeft);
        EventBus.Instance.Subscribe<ChipSelectedEvent>(ClickOnChipMouseLeft);
    }

    private void ClickOnChipMouseLeft(object clickedObject)
    {
        if (movining)
        {
            return;
        }
        selectedChip = clickedObject as ChipBase;

        var nodeClicked = selectedChip.Node;
        _path = null;

        if (!_gridManager.CheckPosition(nodeClicked.PosX, nodeClicked.PosY))
        {
            return;
        }

        PathBuilding();
    }

    private void PathBuilding()
    {
        pathfinding.Clear();
        List<PathNode> toHighlight = pathfinding.CalculateWalkableTerrain(selectedChip.Node,
                                             selectedChip.MaxCellMove);
        for (int i = 0; i < toHighlight.Count; i++)
        {
            var pos = toHighlight[i].GetPosition();
            _highLghitCells.SetHighLightCell(pos);
        }
    }

    private void ClickOnCellMouseLeft(object clickedObject)
    {
        if (movining)
        {
            return;
        }
        var nodeClicked = clickedObject as Node;
        if (selectedChip == null)
        {
            selectedChip = nodeClicked.Chip;
            if (selectedChip == null)
            {
                Debug.Log("Не выбран герой");
                return;
            }
            EventBus.Instance.Publish<ChipBase>(selectedChip);
        }
        if (_path != null)
        {
            StartCoroutine(FollowPath());
            return;
        }
        _highLghitCells.ResetAllHighLightCell();
        _path = pathfinding.TrackBackPath(nodeClicked.PosX, nodeClicked.PosY);
        if (_path != null)
        {
            for (int i = 0; i < _path.Count; i++)
            {
                var pos = _path[i].GetPosition();
                _highLghitCells.SetHighLightCell(pos);
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
        if (!_path.Any())
        {

            Debug.Log("Нет пути");
            yield break;
        }

        yield return selectedChip.Move(_path);

        var node = _gridManager.GetNode(_path[0].xPos, _path[0].yPos);
        selectedChip.Stop(node);
        pathfinding.Clear();
        movining = false;
        _path = null;
        _highLghitCells.ResetAllHighLightCell();
        selectedChip = null;
    }

    void OnDestroy()
    {
        // Отписка от события при уничтожении объекта
        EventBus.Instance.Unsubscribe<Node>(ClickOnCellMouseLeft);
        EventBus.Instance.Unsubscribe<ChipSelectedEvent>(ClickOnChipMouseLeft);
    }
}
