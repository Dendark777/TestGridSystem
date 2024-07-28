using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TileChipManager : TileBaseManager<ChipInfoePrepareForGame>
    {
        private void Start()
        {
            base.Start();
            SetMaxCountTile(LevelConstants.MaxCountChip);
            AddTile();
        }



    }
}
