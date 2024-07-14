using Assets.Scripts.StartLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Players
{
    [Serializable]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private ChipControl _chipControl;
        [SerializeField]
        private List<ChipBase> _chips;

        public string Name { get; private set; }
        public Color Color { get; private set; }
        public bool IsPlaying { get; private set; }

        public void Init(string name, Color color)
        {
            Name = name;
            Color = color;
            InitChip();
            _chipControl.Init(_chips);
        }

        public void InitChip()
        {
            var gm = LevelManager.Instance.GridManager;
            int x = 1;
            int y = 1;
            foreach (var chip in _chips)
            {
                chip.Init(gm.GetNode(x, y), $"Chip {x}", Color);
                x++;
                y++;
            }
        }

    }
}
