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
    //private SaveLoadMap _saveLoadMap;

    void Awake()
    {
        _nodes = _map.GetComponentsInChildren<Node>();
        //_grid = GetComponent<GridMap>();
        //_saveLoadMap = GetComponent<SaveLoadMap>();

        //_tilemap.ClearAllTiles();
        //_saveLoadMap.Load(_grid);

        //UpdateTileMap();
    }

    //private void UpdateTileMap()
    //{
    //    for (int x = 0; x < _grid.Width; x++)
    //    {
    //        for (int y = 0; y < _grid.Height; y++)
    //        {
    //            UpdateTile(x, y);
    //        }
    //    }
    //}

    //private void UpdateTile(int x, int y)
    //{
    //    var tile = _grid.GetTile(x, y);
    //    if (tile == null)
    //    {
    //        return;
    //    }
    //    //_map.SetTile(new Vector3Int(x, y, 0), _tileSet.GetTile(tile));
    //}

    //public void Set(int x, int y, int to)
    //{
    //    _grid.SetTile(x, y, to);
    //    UpdateTile(x, y);

    //}

    public Node[,] ReadTileMap()
    {
        //if (_map == null)
        //{
        //    _map = GetComponent<Tilemap>();
        //}

        //int sizeX = _map.size.x;
        //int sizeY = _map.size.y;
        if (_mapData != null)
        {
            return _mapData;
        }
        int sizeX = 24;
        int sizeY = 20;
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

    //internal void SetTile(int x, int y, Node node)
    //{
    //    if (node == null)
    //    {
    //        return;
    //    }
    //    if (_map == null)
    //    {
    //        _map = GetComponent<Tilemap>();
    //    }
    //    _map.SetTile(new Vector3Int(x, y, 0), _tileSet.GetTile(node));
    //}

    //internal void Clear()
    //{
    //    if (_map == null)
    //    {
    //        _map = GetComponent<Tilemap>();
    //    }
    //    _map.ClearAllTiles();
    //}

    public Node GetNode(int x, int y)
    {
        return _mapData[x, y];
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
