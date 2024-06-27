using Assets.Scripts.Nodes;
using Assets.Scripts.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.StartLevel
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private GridManager _gridManager;
        [SerializeField]
        HighLightCell _highLghitCells;
        [SerializeField]
        private PlayersManager _curentPlayer;
        private List<PlayersManager> _players;
        public static LevelManager Instance;
        public GridManager GridManager => _gridManager;
        public HighLightCell HighLightCell => _highLghitCells;

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
        }

        public void StartLevel()
        {
            _gridManager.Init();
            _curentPlayer.Init();
        }
    }
}
