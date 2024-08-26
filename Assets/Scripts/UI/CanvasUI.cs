using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.PlacementChips;
using Assets.Scripts.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class CanvasUI : MonoBehaviour
    {
        [SerializeField]
        private ListSelectCharacter selectCharacterPanel;
        [SerializeField]
        private GameObject panelPrepareForGame;
        [SerializeField]
        private GameObject managerPlacementChips;

        private void Start()
        {
            selectCharacterPanel.gameObject.SetActive(false);
            managerPlacementChips.SetActive(false);
            panelPrepareForGame.SetActive(true);
            EventBus.Instance.Subscribe<StartSelectCharacter>(ShowPanelSelectCharacter);
            EventBus.Instance.Subscribe<SelectedCharacter>(HidePanelSelectCharacter);
            EventBus.Instance.Subscribe<StartPlacementChips>(HidePanelPrepareForGame);
        }

        private void ShowPanelSelectCharacter(object eventData)
        {
            selectCharacterPanel.gameObject.SetActive(true);
        }
        
        private void HidePanelSelectCharacter(object eventData)
        {
            selectCharacterPanel.gameObject.SetActive(false);
        }
        private void HidePanelPrepareForGame(object eventData)
        {
            panelPrepareForGame.SetActive(false);
            managerPlacementChips.SetActive(true);
            var tiles = eventData as List<PlayerSetingsPrepareForGame>;
            managerPlacementChips.GetComponent<PlayerSetingsPlacementChips>().Init(tiles);
        }

        private void OnDestroy()
        {
            EventBus.Instance.Unsubscribe<StartSelectCharacter>(ShowPanelSelectCharacter);
            EventBus.Instance.Unsubscribe<SelectedCharacter>(ShowPanelSelectCharacter);
            EventBus.Instance.Unsubscribe<StartPlacementChips>(HidePanelPrepareForGame);
        }
    }
}
