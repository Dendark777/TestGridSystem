using Assets.Scripts.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textMesh;
        [SerializeField]
        private Image _slot1;

        private PlayersManager _playersManager;
        private Player _currentPlayer;
        private ChipBase _currentChip;

        public void SetCurrentPlayer(PlayersManager pm)
        {
            Debug.Log($"PlayerUI Порядок в уровне {Constants.OrderFuntion()}");
            _playersManager = pm;
            _currentPlayer = pm.GetPlayer();
            _textMesh.text = _currentPlayer.Name;
            EventBus.Instance.Subscribe<ChipBase>(SetCurrentChip);

        }

        public void SetCurrentChip(object eventData)
        {
            var chip = eventData as ChipBase;
            _slot1.sprite = chip.Inventory.Items[0].Sprite;
        }
    }
}
