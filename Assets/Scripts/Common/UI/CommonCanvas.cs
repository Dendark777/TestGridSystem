using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class CommonCanvas : MonoBehaviour
    {
        [SerializeField]
        private GameObject levelUI;
        [SerializeField]
        private GameObject lobbyHotSeat;
        [SerializeField]
        private GameObject managerPlacementChips;

        private void Start()
        {
            levelUI.SetActive(false);
            managerPlacementChips.SetActive(false);
            lobbyHotSeat.SetActive(true);
            EventBus.Instance.Subscribe<StartPlacementChips>(HidePanelPrepareForGame);
        }


        private void HidePanelPrepareForGame(object eventData)
        {
            lobbyHotSeat.SetActive(false);
            levelUI.SetActive(false);
            managerPlacementChips.SetActive(true);
        }

        private void OnDestroy()
        {
            EventBus.Instance.Unsubscribe<StartPlacementChips>(HidePanelPrepareForGame);
        }
    }
}
