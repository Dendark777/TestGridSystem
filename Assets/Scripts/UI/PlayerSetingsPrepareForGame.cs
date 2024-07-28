using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Players
{
    public class PlayerSetingsPrepareForGame : MonoBehaviour
    {
        [SerializeField]
        private Toggle _isZombie;
        [SerializeField]
        private TextMeshProUGUI _namePlayer;
        [SerializeField]
        private GameObject _colorPlayer;
        [SerializeField]
        private GameObject _chipPanelPlayer;
        [SerializeField]
        private Toggle _isReady;
        public bool IsZombie => _isZombie.isOn;
        public bool IsReady => _isReady.isOn;
        private void Start()
        {
            ToggleGroup _toggleGroup = transform.parent.GetComponent<PrepareForGame>().ToggleGroup;
            _isZombie.group = _toggleGroup;
            SetActiveColorPlayer(_isZombie.isOn);
            SetActiveChipPanelPlayer(_isZombie.isOn);
            _isZombie.onValueChanged.AddListener(SetActiveColorPlayer);
            _isZombie.onValueChanged.AddListener(SetActiveChipPanelPlayer);
            _isReady.onValueChanged.AddListener(CheckIsReady);
        }

        public void CheckIsReady(bool isOn)
        {
            EventBus.Instance.Publish<PlayerIsReady>(isOn);
        }

        void SetActiveColorPlayer(bool isOn)
        {
            _colorPlayer.SetActive(!isOn);
        }
        void SetActiveChipPanelPlayer(bool isOn)
        {
            _chipPanelPlayer.SetActive(!isOn);
        }

        public string GetNamePlayer()
        {
            return _namePlayer.text;
        }

        public Color GetColorPlayer()
        {
            return _colorPlayer.GetComponent<ColorPicker>().GetColor();
        }

        public List<ChipInfoePrepareForGame> GetChips()
        {
            var panel = _chipPanelPlayer.GetComponent<TileChipManager>();
            var tiles = panel.GetTiles();
            var chips = new List<ChipInfo>();
            //foreach (var tile in tiles)
            //{
            //    chips.Add(new ChipInfo(
            //}
            return tiles;
        }

        public void SetIsZombie()
        {
            _isZombie.isOn = true;
        }
    }
}
