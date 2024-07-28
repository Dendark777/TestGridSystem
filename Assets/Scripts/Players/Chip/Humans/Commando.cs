using Assets.Scripts.Nodes;
using Assets.Scripts.Players.Chip.Humans;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Players.Chip.Humans
{
    public class Commando : HumanBase
    {
        private void Start()
        {
            SpecificInitParameters("Спецназовец");
        }
    }
}
