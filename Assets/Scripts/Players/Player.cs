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
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public bool IsPlaying { get; private set; }
        private List<ChipBase> _chips;

        public void Init(string name, Color color, List<ChipBase> chips)
        {
            Name = name;
            Color = color;
            _chips = chips;
            _chipControl.Init();
        }
    }
}
