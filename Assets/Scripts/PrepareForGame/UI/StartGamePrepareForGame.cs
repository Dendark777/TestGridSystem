using Assets.Scripts.EventsBus.UIEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class StartGamePrepareForGame : MonoBehaviour
    {
        [SerializeField]
        private TilePlayerSetingsManager tilePlayerSetingsManager;
        public void StartGame()
        {
            EventBus.Instance.Publish<StartPlacementChips>(tilePlayerSetingsManager.GetTiles());
            print("Старт игры"); 
        }
    }
}
