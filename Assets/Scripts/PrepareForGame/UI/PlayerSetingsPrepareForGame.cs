using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.PrepareForGame.UI;
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
        private GameObject _peoplePanelPlayer;
        [SerializeField]
        private GameObject _zombiePanelPlayer;
        [SerializeField]
        private Toggle _isReady;
        public bool IsZombie => _isZombie.isOn;
        public bool IsReady => _isReady.isOn;
        private void Start()
        {
            ToggleGroup _toggleGroup = transform.parent.GetComponent<GetToggleGroup>().ToggleGroup;
            _isZombie.group = _toggleGroup;
            _isZombie.onValueChanged.AddListener(SetPlayerSide);
            _isReady.onValueChanged.AddListener(CheckIsReady);
            SetPlayerSide(_isZombie.isOn);
        }

        public void CheckIsReady(bool isOn)
        {
            EventBus.Instance.Publish<PlayerIsReady>(isOn);
        }

        public void SetPlayerSide(bool isOn)
        {
            _peoplePanelPlayer.SetActive(!isOn);
            _zombiePanelPlayer.SetActive(isOn);
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
            var goPanel = _isZombie ? _zombiePanelPlayer : _peoplePanelPlayer;
            var panel = goPanel.GetComponent<TileChipManager>();
            var tiles = panel.GetTiles();
            return tiles;
        }

        public void SetIsZombie()
        {
            _isZombie.isOn = true;
        }
    }
}
