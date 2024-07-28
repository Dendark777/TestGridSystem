using Assets.Scripts.EventsBus.PlayersEvents;
using Assets.Scripts.EventsBus.UIEvents;
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
        [SerializeField]
        private GameObject _prepareForGamePanel;
        [SerializeField]
        private GameObject _toggleGroup;
        [SerializeField]
        private GameObject _startGame;
        [SerializeField]
        private GameObject _levelUI;

        private Player _currentPlayer;

        private void Awake()
        {
            EventBus.Instance.Subscribe<StartTurnPlayer>(SetPlayer);
            EventBus.Instance.Subscribe<StartPrepareForGame>(StartPrepareForGame);
            EventBus.Instance.Subscribe<StartLevelGame>(StartLevelGame);
        }

        private void StartPrepareForGame(object eventData)
        {
            _prepareForGamePanel.SetActive(true);
            _toggleGroup.SetActive(true);
            _startGame.SetActive(true);
            _levelUI.SetActive(false);
        }

        private void StartLevelGame(object eventData)
        {
            _prepareForGamePanel.SetActive(false);
            _toggleGroup.SetActive(false);
            _startGame.SetActive(false);
            _levelUI.SetActive(true);
        }

        public void SetPlayer(object eventData)
        {
            var player = eventData as Player;
            _currentPlayer = player;
            _namePlayer.text = _currentPlayer.Name;
        }

        public void OnDestroy()
        {
            EventBus.Instance.Unsubscribe<StartTurnPlayer>(SetPlayer);
            EventBus.Instance.Unsubscribe<StartPrepareForGame>(StartPrepareForGame);
            EventBus.Instance.Unsubscribe<StartLevelGame>(StartLevelGame);
        }
    }
}
