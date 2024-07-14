using Assets.Scripts.EventsBus.ChipEvents;
using Assets.Scripts.Items.Weapons;
using Assets.Scripts.Players;
using Assets.Scripts.Players.Chip.ChipEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ChipInfo : MonoBehaviour
    {
        private ChipBase _currentChip;
        [SerializeField]
        private Image _currentItem;
        [SerializeField]
        private TextMeshProUGUI _currentItemName;
        [SerializeField]
        private TextMeshProUGUI _currentChipName;
        public void Start()
        {
            EventBus.Instance.Subscribe<ChipSelectedEvent>(SetCurrentChip);
            EventBus.Instance.Subscribe<ChipDeselectedEvent>(ClearChip);
            EventBus.Instance.Subscribe<ChipSelectWeaponEvent>(ShowCurrentItem);
        }

        public void SetCurrentChip(object eventData)
        {
            _currentChip = eventData as ChipBase;
            if (_currentChip == null )
            {
                return;
            }
            _currentChipName.text = _currentItem.name;
            ShowCurrentItem(_currentChip.GetSelectedWeapon());
        }

        public void ShowCurrentItem(object eventData)
        {

            Weapon weapon = eventData as Weapon;
            if (_currentChip == null)
            {
                return;
            }
            _currentItem.sprite = weapon.Sprite;
            _currentItemName.text = weapon.ItemName;
        }

        public void ClearChip(object eventData)
        {
            _currentItem.sprite = null;
        }

        private void OnDestroy()
        {
            EventBus.Instance.Unsubscribe<ChipSelectedEvent>(SetCurrentChip);
            EventBus.Instance.Unsubscribe<ChipDeselectedEvent>(ClearChip);
        }
    }
}
