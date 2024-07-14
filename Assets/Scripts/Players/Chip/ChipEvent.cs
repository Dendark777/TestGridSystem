using Assets.Scripts.EventsBus.ChipEvents;
using Assets.Scripts.Items.Weapons;
using Assets.Scripts.Players.Chip.ChipEvents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Players.Chip
{
    public class ChipEvent : MonoBehaviour
    {
        private ChipBase _chip;

        private void Start()
        {
            _chip = GetComponent<ChipBase>();
        }

        void OnMouseDown()
        {
            EventBus.Instance.Subscribe<ChipSelectedEvent>(Selected);
            EventBus.Instance.Publish<ChipClickEvent>(_chip);
        }

        public void Selected(object eventData)
        {
            EventBus.Instance.Subscribe<InventoryOnValueChange>(SelectedWeapon);
        }
        public void Deselected()
        {
            Unsubscribe();
            EventBus.Instance.Publish<ChipDeselectedEvent>(_chip);
        }

        public void SelectedWeapon(object dataEvent)
        {
            var index = dataEvent as int?;
            _chip.SelectWeapon(index.Value);
            EventBus.Instance.Publish<ChipSelectWeaponEvent>(_chip.GetSelectedWeapon());
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            EventBus.Instance.Unsubscribe<ChipSelectedEvent>(Selected);
            EventBus.Instance.Unsubscribe<InventoryOnValueChange>(SelectedWeapon);
        }
    }
}
