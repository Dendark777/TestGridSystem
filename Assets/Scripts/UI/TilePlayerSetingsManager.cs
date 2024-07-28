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
    public class TilePlayerSetingsManager : TileBaseManager<PlayerSetingsPrepareForGame>
    {
        [SerializeField]
        private Button _startGame;
        private void Start()
        {
            base.Start();
            SetMaxCountTile(LevelConstants.MaxCountPlayer);
            EventBus.Instance.Subscribe<PlayerIsReady>(ReadyForGame);
            for (int i = 0; i < 2; i++)
            {
                AddTile();
            }
            _startGame.enabled = CheckReadyForGame();
        }
        private void ReadyForGame(object eventData)
        {
            _startGame.enabled = CheckReadyForGame();
        }

        private bool CheckReadyForGame()
        {
            return _tiles.TrueForAll(t => t.IsReady) && _tiles.Exists(t => t.IsZombie);
        }


    }
}
