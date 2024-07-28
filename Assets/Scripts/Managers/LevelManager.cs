using Assets.Scripts.Nodes;
using Assets.Scripts.Players;
using Assets.Scripts.UI;
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
        private PlayerUI _ui;
        //private List<PlayersManager> _players;
        private PlayersManager _playerManager;
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

        //Порядок в уровне 2
        public void StartLevel()
        {
            Init();
            _playerManager = new PlayersManager();
            _ui.SetPlayer(GetCurrentPlayer());
        }
        public void StartLevel(List<Player> players)
        {
            Init();
            _playerManager = new PlayersManager(players);
            _ui.SetPlayer(GetCurrentPlayer());
        }

        private void Init()
        {
            _gridManager.Init();
        }

        public Transform GetTransformMap()
        {
            return _gridManager.transform;
        }

        public Node GetNode(int x, int y)
        {
            return GridManager.GetNode(x, y);
        }

        public Node GetLegalNode(int x, int y)
        {
            Node node;
            int i = 0;
            do
            {
                i++;
                node = GridManager.GetNode(x + i, y + i);
            } while (!GridManager.CheckStopable(x + i, y + i));
            return node;
        }

        public Player GetCurrentPlayer()
        {
            return _playerManager.GetCurrntPlayer();
        }

    }
}
