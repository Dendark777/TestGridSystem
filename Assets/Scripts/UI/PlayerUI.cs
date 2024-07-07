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
        private TextMeshProUGUI _textMesh;


        private PlayersManager _playersManager;
        private Player _currentPlayer;

        public void SetCurrentPlayer(PlayersManager pm)
        {
            _playersManager = pm;
            _currentPlayer = pm.GetPlayer();
            _textMesh.text = _currentPlayer.Name;
        }
    }
}
