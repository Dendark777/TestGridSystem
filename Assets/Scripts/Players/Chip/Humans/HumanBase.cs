using Assets.Scripts.Constants;
using Assets.Scripts.Helpers.Parameters;
using Assets.Scripts.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Players.Chip.Humans
{
    public class HumanBase : ChipBase
    {
        public override void Init(Node node, Color playerColor)
        {
            base.Init(node, playerColor);
            InitBaseParameters(new HumanParameters());
        }
    }
}
