using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Players
{
    [Serializable]
    public class Player
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public CharacterControl CharacterControl { get; set; }
        public bool IsPlaying { get; set; }
        public List<ChipBase> Characters { get; set; }

        public Player(string name, Color color, List<ChipBase> characters)
        {
            Name = name;
            Color = color;
            Characters = characters;
        }
    }
}
