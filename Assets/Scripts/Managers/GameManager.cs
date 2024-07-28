using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.MachineState;
using Assets.Scripts.Players;
using Assets.Scripts.StartLevel;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private LevelManager _levelManager;
        [SerializeField]
        private TilePlayerSetingsManager _tilePlayerSetingsManager;
        private IState _currentState;
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            EventBus.Instance.Subscribe<StartLevelGame>(StartLevel);
        }

        public void StartLevel(object eventData)
        {
            var players = new List<Player>();
            int i = 0;
            foreach (var player in _tilePlayerSetingsManager.GetTiles())
            {
                var pName = string.IsNullOrEmpty(player.GetNamePlayer()) ? $"Игрок {i}" : player.GetNamePlayer();
                players.Add(new Player(pName, player.GetColorPlayer(), i++, player.GetChips().Count));
            }
            _levelManager.StartLevel(players);
        }
    }

}
