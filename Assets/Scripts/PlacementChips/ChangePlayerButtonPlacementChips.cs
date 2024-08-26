using Assets.Scripts.EventsBus.UIEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlacementChips
{
    public class ChangePlayerButtonPlacementChips : MonoBehaviour
    {
        public void ChangePlayer(int i)
        {
            EventBus.Instance.Publish<ChangePlayerByIndexPlacementChips>(i);
        }
    }
}
