using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlacementChips
{
    public class ChipsPanelPlacementChips : MonoBehaviour
    {

        public void AddChip(List<ChipInfoePrepareForGame> chipInfoePrepareForGames)
        {
            chipInfoePrepareForGames.ForEach(chipInfo => chipInfo.transform.SetParent(transform, false));
        }
    }
}
