using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class TileBaseManager<T> : MonoBehaviour
    {
        [SerializeField]
        private GameObject _tilePrefab; // Префаб плитки
        [SerializeField]
        private RectTransform _tilePanel; // Панель для размещения плиток
        [SerializeField]
        private Button _addTileButton; // Кнопка для добавления плиток
        private int _maxCountTile;
        protected List<T> _tiles;

        protected void Start()
        {
            _tiles = new List<T>();
            _addTileButton?.onClick.AddListener(AddTile);
        }

        protected void SetMaxCountTile(int maxCountTile)
        {
            _maxCountTile = maxCountTile;
        }

        public virtual void AddTile()
        {
            if (_tiles.Count >= _maxCountTile)
            {
                return;
            }
            GameObject newTile = Instantiate(_tilePrefab, _tilePanel);
            newTile.SetActive(true);
            _tiles.Add(newTile.GetComponent<T>());
            _addTileButton?.transform.SetAsLastSibling();
        }


        public List<T> GetTiles()
        {
            return _tiles;
        }

        internal void RemoveTile()
        {
            throw new NotImplementedException();
        }
    }
}
