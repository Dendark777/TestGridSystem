//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SaveLoadMap : MonoBehaviour
//{
//    [SerializeField]
//    MapData _mapData;

//    [SerializeField]
//    GridMap gridMap;
//    [SerializeField]
//    GridManager gridManager;

//    public void Save()
//    {
//        Node[,] map = gridManager.ReadTileMap();
//        _mapData.Save(map);
//    }

//    public void Load()
//    {
//        gridManager.Clear();
//        int width = _mapData.width;
//        int height = _mapData.height;
//        int i = 0;
//        for (int x = 0; x < width; x++)
//        {
//            for (int y = 0; y < height; y++)
//            {
//                if (_mapData.map[i] == null)
//                {
//                    gridManager.SetTile(x, y, _mapData.map[i]);
//                }
//                i++;
//            }
//        }
//    }

//    public void Load(GridMap grid)
//    {
//        _mapData.Load(grid);
//    }
//}
