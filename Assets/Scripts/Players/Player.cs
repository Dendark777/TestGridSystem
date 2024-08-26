using Assets.Scripts.EventsBus.PlayersEvents;
using Assets.Scripts.Helpers;
using Assets.Scripts.Helpers.Parameters;
using Assets.Scripts.StartLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Players
{
    public class Player
    {
        private ChipControl _chipControl;
        private readonly string prefabPath = "Prefabs/Chips/Human";
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public bool IsPlaying { get; private set; }
        private readonly int _countChip;
        public Player(string name, Color color) : this(name, color, 2)
        {
            InitChip(new CommandoParameters());
        }
        public Player(string name, Color color, int chips)
        {
            Name = name;
            Color = color;
            IsPlaying = false;
            _countChip = chips;
        }

        public void ArrangementChip()
        {

        }

        public void InitChip(BaseParameters parameters)
        {
            var _chips = new List<ChipBase>();
            GameObject humanPrefab = Resources.Load<GameObject>(prefabPath);
            var human = InstantiateHelper.Instance.InstantiatePrefab(humanPrefab);
            human.transform.SetParent(LevelManager.Instance.GridManager.transform);
            var component = human.GetComponent<ChipBase>();
            component.Init(LevelManager.Instance.GetLegalNode(1, 1), Color, parameters);
            _chips.Add(human.GetComponent<ChipBase>());
            _chipControl = new ChipControl(_chips);
        }



        public void StartTurn()
        {
            _chipControl.StartTurnPlayer();
        }

        public void EndTurn()
        {
            _chipControl.EndTurnPlayer();
        }

        //public void InitChip(HumanBase chip, int x, int y)
        //{
        //    var gm = LevelManager.Instance.GridManager;
        //    chip.Init(gm.GetNode(x, y), Color);
        //}

    }
}
