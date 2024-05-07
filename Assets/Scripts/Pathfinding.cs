using Assets.Scripts.Nodes;
using Assets.Scripts.TileSetData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    public int xPos;
    public int yPos;
    public int gValue;
    public int hValue;
    public PathNode parentNode;
    public int FValue { get { return gValue + hValue; } }

    public PathNode(int xPos, int yPos)
    {
        this.xPos = xPos;
        this.yPos = yPos;
    }

    internal void Clear()
    {
        gValue = 0;
        hValue = 0;
        parentNode = null;
    }

    public Vector3 GetPosition() { return new Vector3(xPos, yPos, 0); }
}

[RequireComponent(typeof(GridMap))]
public class Pathfinding : MonoBehaviour
{
    GridMap gridMap;
    PathNode[,] pathNodes;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if (gridMap == null)
        {
            gridMap = GetComponent<GridMap>();
        }
        pathNodes = new PathNode[gridMap.Width, gridMap.Height];
        for (int x = 0; x < gridMap.Width; x++)
        {
            for (int y = 0; y < gridMap.Height; y++)
            {
                pathNodes[x, y] = new PathNode(x, y);
            }
        }
    }

    public void CalculateWalkableTerrain(Node startNode, int range, ref List<PathNode> toHighlight)
    {
        range *= 10;

        PathNode starNode = pathNodes[startNode.PosX, startNode.PosY];

        List<PathNode> openList = new List<PathNode>();
        List<PathNode> closedList = new List<PathNode>();

        openList.Add(starNode);

        while (openList.Count > 0)
        {
            PathNode currentNode = openList[0];


            openList.Remove(currentNode);
            closedList.Add(currentNode);

            List<PathNode> neighbors = GetNeighbourNodes(currentNode);
            for (int i = 0; i < neighbors.Count; i++)
            {
                if (closedList.Contains(neighbors[i]))
                    continue;
                if (!gridMap.CheckWalkable(neighbors[i].xPos, neighbors[i].yPos))
                    continue;

                int moveCost = currentNode.gValue + CalculateDistance(currentNode, neighbors[i]);

                if (moveCost > range)
                    continue;

                if (!openList.Contains(neighbors[i]) ||
                    moveCost < neighbors[i].gValue)
                {
                    neighbors[i].gValue = moveCost;
                    neighbors[i].parentNode = currentNode;

                    if (!openList.Contains(neighbors[i]))
                        openList.Add(neighbors[i]);
                }
            }
        }
        toHighlight?.AddRange(closedList);
    }

    private List<PathNode> GetNeighbourNodes(PathNode currentNode)
    {
        var tileType = gridMap.GetTile(currentNode.xPos, currentNode.yPos).TileTypes[0];
        GetNeighbourNodes check = NodesTypeCheck.TypeChecks[tileType];
        List<PathNode> neighbourNodes = new List<PathNode>();
        try
        {

            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    //Y вертикаль
                    //X горизонталь
                    if (x == 0 && y == 0)
                        continue;
                    if (!gridMap.CheckPosition(currentNode.xPos + x, currentNode.yPos + y))
                        continue;
                    if (check.CheckNeighbourNode(x, y, currentNode, gridMap))
                        continue;
                    neighbourNodes.Add(pathNodes[currentNode.xPos + x, currentNode.yPos + y]);
                }
            }
        }
        catch (Exception e)
        {
            print(e);
        }
        return neighbourNodes;
    }

    private List<PathNode> RetracePath(PathNode startNode, PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();

        PathNode currentNode = endNode;
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parentNode;
        }
        path.Reverse();
        return path;
    }

    private int CalculateDistance(PathNode current, PathNode target)
    {
        int distX = Math.Abs(current.xPos - target.xPos);
        int distY = Math.Abs(current.yPos - target.yPos);

        if (distX > distY)
        {
            return 14 * distY + 10 * (distX - distY);
        }
        return 14 * distX + 10 * (distY - distX);
    }

    public List<PathNode> TrackBackPath(int x, int y)
    {
        List<PathNode> path = new List<PathNode>();
        PathNode currentNode = pathNodes[x, y];

        while (currentNode.parentNode != null)
        {
            path.Add(currentNode);
            currentNode = currentNode.parentNode;
        }
        return path;
    }

    internal void Clear()
    {
        for (int x = 0; x < gridMap.Width; x++)
        {
            for (int y = 0; y < gridMap.Height; y++)
            {
                try
                {
                    pathNodes[x, y].Clear();
                }
                catch (Exception)
                {

                    print($"x={x} y={y}");
                }
            }
        }
    }
}
