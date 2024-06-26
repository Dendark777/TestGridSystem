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

    public Node GetNode(int x, int y)
    {
        return _grid.GetNode(x, y);
    }
    
    public Node GetRandomNode()
    {
        var r = new  Unity.Mathematics.Random();
        return GetNode(r.NextInt(Constants.MapSizeX), r.NextInt(Constants.MapSizeY));
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
