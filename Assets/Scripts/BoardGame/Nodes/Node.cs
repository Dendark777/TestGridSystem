using Assets.Scripts.Players;
using Assets.Scripts.TileSetData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public ChipBase Chip;
        public delegate void ClickAction(GameObject clickedObject);
        public static event ClickAction OnNodeLeftClicked;
        public static event ClickAction OnNodeRightClicked;
        public void Init(int x, int y)
        {
            PosX = x;
            PosY = y;
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

        void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnNodeLeftClicked?.Invoke(gameObject);

            }
            else if (Input.GetMouseButtonDown(1))
            {
                OnNodeRightClicked?.Invoke(gameObject);

            }
        }
    }
}
