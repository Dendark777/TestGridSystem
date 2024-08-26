using Assets.Scripts.EventsBus.PlayersEvents;
using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.PlacementChips
{
    public class PlayerSetingsPlacementChips : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _playerName;
        [SerializeField]
        private ChipsPanelPlacementChips _chipsPanelPlacementChips;
        private PlayerSetingsPrepareForGame currentPlayer;
        private Image _backgroundColor;
        private List<PlayerSetingsPrepareForGame> _tiles;
        private int indexPlayer;
        private void Start()
        {
            _backgroundColor = GetComponent<Image>();
            indexPlayer = -1;
            EventBus.Instance.Subscribe<ChangePlayerByIndexPlacementChips>(ChangePlayerByIndex);
        }

        public void Init(List<PlayerSetingsPrepareForGame> tiles)
        {
            _tiles = tiles;
            ChangePlayerByIndex(1);
        }

        private void ChangePlayerByIndex(object eventData)
        {
            var p = eventData as int?;
            indexPlayer += p.GetValueOrDefault(0);
            if (indexPlayer >= _tiles.Count || indexPlayer < 0)
            {
                indexPlayer = 0;
            }
            SetCurrentPlayer(_tiles[indexPlayer]);
        }

        public void SetCurrentPlayer(PlayerSetingsPrepareForGame player)
        {
            currentPlayer = player;
            _playerName.text = currentPlayer.GetNamePlayer();
            _backgroundColor.color = currentPlayer.GetColorPlayer();
            _chipsPanelPlacementChips.AddChip(currentPlayer.GetChips());
        }
    }
}
