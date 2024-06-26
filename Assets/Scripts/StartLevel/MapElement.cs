using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapElement : MonoBehaviour
{
    GridMap gridMap;
    void Start()
    {
        SetGrid();
        PlaceObjectOnGrid();
    }

    private void SetGrid()
    {
        gridMap = transform.parent.GetComponent<GridMap>();
    }

    public void PlaceObjectOnGrid()
    {
        Transform t = transform;
        Vector3 pos = t.position;
        int xPos = (int)pos.x;
        int yPos = (int)pos.y;
        gridMap.SetCharacter(this, xPos, yPos);
    }
}
