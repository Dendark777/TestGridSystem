using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SelectCharacterCell : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image Logo;
        [SerializeField]
        private TextMeshProUGUI LogoText;
        private BaseParameters _parameters;
        public void AddCell(BaseParameters parameters)
        {
            _parameters = parameters;
            Logo.sprite = Resources.Load<Sprite>(_parameters.LogoPath);
            LogoText.text = _parameters.Name;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            EventBus.Instance.Publish<SelectedCharacter>(_parameters);
            print("Клик");
        }
    }
}
