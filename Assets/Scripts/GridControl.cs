using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridControl : MonoBehaviour
{
    [SerializeField] Tilemap _targetTilemap;
    [SerializeField] GridManager _gridManager;
    [SerializeField] TileBase _highlighTile;
    Pathfinding _pathfinding;

    int _currentX = 0;
    int _currentY = 0;
    int _targetPosX = 0;
    int _targetPosY = 0;

    private void Start()
    {
        _pathfinding = _gridManager.GetComponent<Pathfinding>();


    }

    private void Update()
    {
        //MouseInput();
    }

    //private void MouseInput()
    //{
    //    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3Int clickPosition = _targetTilemap.WorldToCell(worldPoint);
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        _targetTilemap.ClearAllTiles();
    //        //_gridManager.Set(clickPosition.x, clickPosition.y, 1);

    //        _targetPosX = clickPosition.x;
    //        _targetPosY = clickPosition.y;

    //        List<PathNode> path = _pathfinding.FindPath(_currentX, _currentY, _targetPosX, _targetPosY);
    //        if (path != null)
    //        {
    //            for (int i = 0; i < path.Count; i++)
    //            {
    //                _targetTilemap.SetTile(new Vector3Int(path[i].xPos, path[i].yPos, 0), _highlighTile);
    //            }
    //            _currentX = _targetPosX; 
    //            _currentY = _targetPosY;
    //        }
    //    }
    //}
}
