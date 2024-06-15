using Assets.Scripts;
using Assets.Scripts.Nodes;
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
    [SerializeField] private GameObject _map;
    [SerializeField] private GridMap _grid;

    private Node[] _nodes;
    private Node[,] _mapData;

    void Awake()
    {
        _nodes = _map.GetComponentsInChildren<Node>();
    }

    public Node[,] ReadTileMap()
    {

        if (_mapData != null)
        {
            return _mapData;
        }
        int sizeX = Constants.MapSizeX;
        int sizeY = Constants.MapSizeY;
        Debug.Log($"{sizeX} {sizeY}");
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
        return _mapData;
    }

    public Node GetNode(int x, int y)
    {
        return _mapData[x, y];
    }
    
    public Node GetRandomNode()
    {
        var r = new  Unity.Mathematics.Random();
        return _mapData[r.NextInt(Constants.MapSizeX), r.NextInt(Constants.MapSizeY)];
    }

    public Character GetCharacter(int x, int y)
    {
        return _grid.GetCharacter(x, y);
    }

    internal bool CheckPosition(int x, int y)
    {
        return _grid.CheckPosition(x, y);
    }
}
