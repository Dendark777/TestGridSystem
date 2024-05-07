using Assets.Scripts.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterControl : MonoBehaviour
{
    [SerializeField]
    Tilemap targetTileMap;
    [SerializeField]
    GridManager gridManager;
    [SerializeField]
    HighLightCell highLghitCells;
    [SerializeField]
    Transform Hero;
    [SerializeField]
    Animator Animator;
    [SerializeField]
    Character selectedCharacter;
    [SerializeField]
    Node StartNode;

    [SerializeField]
    Pathfinding pathfinding;
    List<PathNode> path;
    public float moveSpeed = 20f;
    private int targetIndex = 0;
    private bool movining = false;
    private void Awake()
    {
        //pathfinding = targetTileMap.GetComponent<Pathfinding>();
        highLghitCells.Init();
        selectedCharacter.Init(StartNode);
        Node.OnNodeLeftClicked += ClickOnCellMouseLeft;
        //Node.OnNodeRightClicked += ClickOnCellMouseRight;
        Character.OnLeftClicked += ClickOnCharacterMouseLeft;
    }

    private void ClickOnCharacterMouseLeft(GameObject clickedObject)
    {
        if (movining)
        {
            return;
        }
        if (!clickedObject.TryGetComponent<Character>(out selectedCharacter))
        {
            return;
        }
        var nodeClicked = selectedCharacter.Node;
        path = null;

        if (!gridManager.CheckPosition(nodeClicked.PosX, nodeClicked.PosY))
        {
            return;
        }

        List<PathNode> toHighlight = new List<PathNode>();
        pathfinding.Clear();
        pathfinding.CalculateWalkableTerrain(selectedCharacter.Node,
                                             selectedCharacter.MoveDistance,
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
        if (selectedCharacter != null)
        {
            List<PathNode> toHighlight = new List<PathNode>();
            pathfinding.Clear();
            pathfinding.CalculateWalkableTerrain(selectedCharacter.Node,
                                                 selectedCharacter.MoveDistance,
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
        if (selectedCharacter == null)
        {
            Debug.Log("Не выбран герой");
            return;
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
        if (Hero == null)
        {
            Debug.Log("Не выбран герой");
            yield break;
        }
        if (!path.Any())
        {

            Debug.Log("Нет пути");
            yield break;
        }
        Vector3 currentWaypoint;
        try
        {
            targetIndex = path.Count - 1;
            currentWaypoint = path[path.Count - 1].GetPosition();
            movining = true;
            Animator.SetBool("Moving", movining);
            RoteateHero(currentWaypoint);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            yield break;
        }

        while (true)
        {
            if (Hero.position == currentWaypoint)
            {
                targetIndex--;
                if (targetIndex < 0)
                {
                    var node = gridManager.GetNode(path[0].xPos, path[0].yPos);
                    selectedCharacter.SetNode(node);
                    movining = false;
                    path = null;
                    highLghitCells.ResetAllHighLightCell();
                    selectedCharacter = null;
                    Animator.SetBool("Moving", movining);
                    yield break; // Завершаем корутину, если достигли конца пути
                }
                currentWaypoint = path[targetIndex].GetPosition();
                RoteateHero(currentWaypoint);
            }

            Hero.position = Vector3.MoveTowards(Hero.position, currentWaypoint, moveSpeed * Time.deltaTime);
            yield return null; // Ждем один кадр
        }
    }

    private void RoteateHero(Vector3 currentWaypoint)
    {
        // Поворот в сторону следующей точки пути
        Vector2 direction = (currentWaypoint - Hero.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Hero.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnDestroy()
    {
        // Отписка от события при уничтожении объекта
        Node.OnNodeLeftClicked -= ClickOnCellMouseLeft;
        Node.OnNodeRightClicked -= ClickOnCellMouseRight;
        Character.OnLeftClicked -= ClickOnCharacterMouseLeft;
    }
}
