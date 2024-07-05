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
        private bool[] _canStep;
        public bool[] CanStep => _canStep;
        public int PosX { get; set; }
        public int PosY { get; set; }
        public TileType[] TileTypes
        {
            get => _tileTypes;
            set => _tileTypes = value;
        }
        private ChipBase _chip;
        public ChipBase Chip => _chip;
        public delegate void ClickAction(GameObject clickedObject);
        public static event ClickAction OnNodeLeftClicked;
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
            var t = Chip == null && TileTypes[0] != TileType.None;
            return t;
        }

        public List<Point> GetPointsNeighbour()
        {
            var points = new List<Point>();
            for (int i = 0; i < _canStep.Length; i++)
            {
                if (!_canStep[i])
                {
                    continue;
                }
                points.Add(Neighbours.Points[i]);
            }
            return points;
        }

        private void OnMouseDown()
        {
            OnNodeLeftClicked?.Invoke(gameObject);
        }
    }
}
