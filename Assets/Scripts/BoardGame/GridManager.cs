using Assets.Scripts;
using Assets.Scripts.Nodes;
using Assets.Scripts.Players;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

[RequireComponent(typeof(GridMap))]
public class GridManager : MonoBehaviour
{
    [SerializeField] private GridMap _grid;

    //Порядок в уровне 3
    public void Init()
    {
        _grid.InitGrid();
    }

    public Node GetRandomNode()
    {
        var r = new System.Random();
        int x, y;

        do
        {
            x = r.Next(Constants.MapSizeX);
            y = r.Next(Constants.MapSizeY);
        }
        while (!CheckWalkable(x, y));
        return GetNode(x, y);
    }

    public Node GetNode(int x, int y)
    {
        return _grid.GetNode(x, y);
    }

    public ChipBase GetChip(int x, int y)
    {
        return _grid.GetChip(x, y);
    }

    public bool CheckPosition(int x, int y)
    {
        return _grid.CheckPosition(x, y);
    }
    public bool CheckWalkable(int xPos, int yPos)
    {
        return _grid.CheckWalkable(xPos, yPos);
    }

}
