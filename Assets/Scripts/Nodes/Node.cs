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
    public class Node : MonoBehaviour
    {
        [SerializeField]
        private TileType[] _tileTypes;
        public int PosX { get; set; }
        public int PosY { get; set; }
        public TileType[] TileTypes 
        {
            get => _tileTypes;
            set => _tileTypes = value;
        }
        public Character Character { get; set; }
        public delegate void ClickAction(GameObject clickedObject);
        public static event ClickAction OnNodeLeftClicked;
        public static event ClickAction OnNodeRightClicked;
        public void Init(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public Node InitNewNode(int x, int y)
        {
            return new Node
            {
                PosX = x,
                PosY = y,
                TileTypes = TileTypes
            };
        }

        //void OnMouseDown()
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Debug.Log("Left mouse button clicked");
        //    }
        //    else if (Input.GetMouseButtonDown(1))
        //    {
        //        Debug.Log("Right mouse button clicked");
        //    }
        //    else if (Input.GetMouseButtonDown(2))
        //    {
        //        Debug.Log("Middle mouse button clicked");
        //    }
        //    // Проверка, есть ли подписчики на событие
        //    // Вызов события и передача этому событию ссылки на текущий объект
        //    OnNodeLeftClicked?.Invoke(gameObject);
        //}
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
