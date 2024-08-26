using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlacementChips
{
    public class ManagerPlayersPlacementChips : MonoBehaviour
    {
        private void Enable()
        {
            EventBus.Instance.SubscribeOnce<StartPlacementChips>(PlayersPlacement);
        }

        private void PlayersPlacement(object eventData)
        {
        }


        private void OnDestroy()
        {
            OnDisable();
        }
        private void OnDisable()
        {
            EventBus.Instance.Unsubscribe<StartPlacementChips>(PlayersPlacement);
        }
    }
}
