using Assets.Scripts.Players;
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
        private Player _cuurentPlayer;
        [SerializeField]
        private Character _currentCharacter;
        [SerializeField]
        private TextMeshProUGUI _textMesh;

        public void SetCurrentPlayer(Player player)
        {
            _cuurentPlayer = player;
            _textMesh.text = _cuurentPlayer.Name;
        }
    }
}
