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
        public List<GameCharacter> Characters { get; set; }

        public Player(string name, Color color, List<GameCharacter> characters)
        {
            Name = name;
            Color = color;
            Characters = characters;
        }
    }
}
