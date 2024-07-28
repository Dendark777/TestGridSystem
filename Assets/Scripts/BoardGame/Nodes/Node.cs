using Assets.Scripts.Players;
using Assets.Scripts.TileSetData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Nodes
{
    public readonly struct Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }


    }

    public class Node : MonoBehaviour
    {
        [SerializeField]
        private TileType[] _tileTypes;
        [SerializeField]
        private bool[] _neighbours;
        public bool[] Neighbours => _neighbours;
        public int PosX { get; set; }
        public int PosY { get; set; }
        public TileType[] TileTypes
        {
            get => _tileTypes;
            set => _tileTypes = value;
        }
        private ChipBase _chip;
        public ChipBase Chip => _chip;
        public void Init(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public void SetChip(ChipBase chip)
        {
            _chip = chip;
        }

        public bool Walkable()
        {
            return Chip == null && TileTypes[0] != TileType.None;
        }

        public List<Point> GetPointsNeighbour()
        {
            var points = new List<Point>();
            for (int i = 0; i < _neighbours.Length; i++)
            {
                var point = Nodes.Neighbours.Points[i];
                if (!_neighbours[i] || PointOutGrid(point))
                {
                    continue;
                }
                points.Add(point);
            }
            return points;
        }

        public bool PointOutGrid(Point point)
        {
            return PosX + point.X < 0 ||
                   PosY + point.Y < 0 ||
                   PosX + point.X >= LevelConstants.MapSizeX ||
                   PosY + point.Y >= LevelConstants.MapSizeY;
        }

        private void OnMouseDown()
        {
            EventBus.Instance.Publish<Node>(this);

        }
    }
}
