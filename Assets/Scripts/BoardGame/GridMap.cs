using Assets.Scripts;
using Assets.Scripts.Nodes;
using Assets.Scripts.Players;
using Assets.Scripts.TileSetData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMap : MonoBehaviour
{
    public Node[,] Map => _mapData;

    [SerializeField] private GameObject _map;
    private Node[,] _mapData;

    public void InitGrid()
    {
        var _nodes = _map.GetComponentsInChildren<Node>();
        int sizeX = Constants.MapSizeX;
        int sizeY = Constants.MapSizeY;
        _mapData = new Node[sizeX, sizeY];

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                try
                {
                    var cell = _nodes[x * sizeY + y];
                    cell.Init(x, y);
                    _mapData[x, y] = cell;
                }
                catch (Exception e)
                {
                    print(e.Message);
                }
            }
        }
    }


    public Node[,] ReadTileMap()
    {
        return _mapData;
    }

    public void SetTile(int x, int y, Node node)
    {
        if (!CheckPosition(x, y))
        {
            return;
        }
        _mapData[x, y] = node;
    }

    public Node GetNode(int x, int y)
    {
        if (!CheckPosition(x, y))
        {
            Debug.LogWarning($"{x} : {y}");
            return null;
        }
        return _mapData[x, y];
    }

    public bool CheckPosition(int x, int y)
    {
        if (x < 0 || x >= Constants.MapSizeX)
        {
            return false;
        }
        if (y < 0 || y >= Constants.MapSizeY)
        {
            return false;
        }
        return true;
    }

    internal bool CheckWalkable(int xPos, int yPos)
    {
        try
        {
            var node = _mapData[xPos, yPos];
            return node.Walkable();
        }
        catch 
        {
            return false;
        }
    }

    public ChipBase GetChip(int x, int y)
    {
        return _mapData[x, y].Chip;
    }
}
