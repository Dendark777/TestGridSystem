using Assets.Scripts.EventsBus.PlayersEvents;
using Assets.Scripts.Players;
using Assets.Scripts.Players.Chip.ChipEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _namePlayer;

        private Player _currentPlayer;

        private void Awake()
        {
            EventBus.Instance.Subscribe<StartTurnPlayer>(SetPlayer);
        }

        public void SetPlayer(object eventData)
        {
            var player = eventData as Player;
            _currentPlayer = player;
            _namePlayer.text = _currentPlayer.Name;
        }
    }
}
