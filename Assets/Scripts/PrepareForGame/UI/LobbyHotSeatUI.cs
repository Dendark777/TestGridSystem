using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PrepareForGame.UI
{
    public class LobbyHotSeatUI : MonoBehaviour
    {
        [SerializeField]
        private TilePlayerSetingsManager tilePlayerSetingsManager;
        [SerializeField]
        private GameObject _panelSelectCharacter;


        private void OnEnable()
        {
            tilePlayerSetingsManager.gameObject.SetActive(true);
            EventBus.Instance.Subscribe<StartSelectCharacter>(ShowPanelSelectCharacter);
            EventBus.Instance.Subscribe<SelectedCharacter>(HidePanelSelectCharacter);
        }

        private void ShowPanelSelectCharacter(object eventData)
        {
            _panelSelectCharacter.SetActive(true);
        }

        private void HidePanelSelectCharacter(object eventData)
        {
            _panelSelectCharacter.SetActive(false);
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            EventBus.Instance.Unsubscribe<StartSelectCharacter>(ShowPanelSelectCharacter);
            EventBus.Instance.Unsubscribe<SelectedCharacter>(HidePanelSelectCharacter);
        }

    }
}
