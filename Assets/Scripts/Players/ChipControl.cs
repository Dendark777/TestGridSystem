using Assets.Scripts;
using Assets.Scripts.EventsBus.ChipEvents;
using Assets.Scripts.Helpers;
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

public class ChipControl
{
    private readonly GridManager _gridManager;
    private readonly HighLightCell _highLghitCells;
    private readonly List<ChipBase> _chips;
    private ChipBase selectedChip;
    private readonly Pathfinding pathfinding;
    private List<PathNode> _path;
    public ChipControl(List<ChipBase> chips)
    {
        _gridManager = LevelManager.Instance.GridManager;
        _highLghitCells = LevelManager.Instance.HighLightCell;
        _chips = chips;
        _highLghitCells.Init();
        pathfinding = new Pathfinding(_gridManager);
    }

    public void StartTurnPlayer()
    {
        EventBus.Instance.Subscribe<Node>(ClickOnCellMouseLeft);
        EventBus.Instance.Subscribe<ChipClickEvent>(ClickChip);
        EventBus.Instance.Subscribe<ChipDeselectedEvent>(DeSelectChip);
        EventBus.Instance.Subscribe<ChipStopEvent>(ChipStop);
    }

    public void EndTurnPlayer()
    {
        EventBus.Instance.Unsubscribe<Node>(ClickOnCellMouseLeft);
        EventBus.Instance.Unsubscribe<ChipClickEvent>(ClickChip);
        EventBus.Instance.Unsubscribe<ChipDeselectedEvent>(DeSelectChip);
        EventBus.Instance.Unsubscribe<ChipStopEvent>(ChipStop);
    }

    private void ClickChip(object clickedObject)
    {
        if (selectedChip != null)
        {
            if (selectedChip.IsMove)
            {
                return;
            }
            selectedChip.Deselected();
        }
        var clickedChip = clickedObject as ChipBase;
        if (!_chips.Contains(clickedChip))
        {
            return;
        }
        selectedChip = clickedChip;
        EventBus.Instance.Publish<ChipSelectedEvent>(selectedChip);

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
        if (selectedChip != null && selectedChip.IsMove)
        {
            return;
        }
        if (selectedChip == null)
        {
            Debug.Log("Не выбран герой");
            return;
        }
        if (_path != null)
        {
            FollowPath();
            return;
        }
        var nodeClicked = clickedObject as Node;
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

    void FollowPath()
    {
        if (selectedChip == null)
        {
            Debug.Log("Не выбран герой");
            return;
        }
        if (!_path.Any())
        {

            Debug.Log("Нет пути");
            return;
        }
        var node = _gridManager.GetNode(_path[0].xPos, _path[0].yPos);
        selectedChip.StartMove(_path, node);
    }

    public void ChipStop(object dataEvent)
    {
        EventBus.Instance.Publish<ChipDeselectedEvent>(selectedChip);
    }

    private void DeSelectChip(object eventData)
    {
        pathfinding.Clear();
        _path = null;
        _highLghitCells.ResetAllHighLightCell();
        selectedChip = null;
    }

    void OnDestroy()
    {
        // Отписка от события при уничтожении объекта
        EventBus.Instance.Unsubscribe<Node>(ClickOnCellMouseLeft);
        EventBus.Instance.Unsubscribe<ChipSelectedEvent>(ClickChip);
        EventBus.Instance.Unsubscribe<ChipDeselectedEvent>(ClickChip);
        EventBus.Instance.Unsubscribe<ChipStopEvent>(ChipStop);

    }
}
