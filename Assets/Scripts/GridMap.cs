using Assets.Scripts.Nodes;
using Assets.Scripts.TileSetData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMap : MonoBehaviour
{
    public GridManager gridManager;
    public int Height { get; private set; }
    public int Width { get; private set; }

    public Node[,] _grid;
    private void Awake()
    {
        InitGrid();
    }
    public void InitGrid()
    {
        _grid = gridManager.ReadTileMap();

        Width = _grid.GetLength(0);// Метод для получения ширины массива
        Height = _grid.GetLength(1);// Метод для получения высоты массива
    }

    public void SetTile(int x, int y, Node node)
    {
        if (!CheckPosition(x, y))
        {
            return;
        }
        _grid[x, y] = node;
    }

    public Node GetNode(int x, int y)
    {
        if (!CheckPosition(x, y))
        {
            Debug.LogWarning($"{x} : {y}");
            return null;
        }
        return _grid[x, y];
    }

    public bool CheckPosition(int x, int y)
    {
        if (x < 0 || x >= Width)
        {
            return false;
        }
        if (y < 0 || y >= Height)
        {
            return false;
        }
        return true;
    }

    internal bool CheckWalkable(int xPos, int yPos)
    {
        try
        {
            return _grid[xPos, yPos].TileTypes[0] != TileType.None;
        }
        catch 
        {
            return false;
        }
    }

    internal void SetCharacter(MapElement mapElement, int xPos, int yPos)
    {
        var c = mapElement.GetComponent<Character>();
        if (_grid[xPos, yPos] == null)
        {
            InitGrid();
        }
        _grid[xPos, yPos].Character = c;
    }

    public Character GetCharacter(int x, int y)
    {
        return _grid[x, y].Character;
    }
}
