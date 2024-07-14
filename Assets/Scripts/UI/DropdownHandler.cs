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
    public class DropdownHandler : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown _dropdown;

        void Start()
        {
            _dropdown.onValueChanged.AddListener(DropdownValueChanged);
            _dropdown.ClearOptions();
            EventBus.Instance.Subscribe<ChipSelectedEvent>(UpdateInventoryList);
            EventBus.Instance.Subscribe<ChipDeselectedEvent>(ClearInvenoty);
        }
        void DropdownValueChanged(int change)
        {
            EventBus.Instance.Publish<InventoryOnValueChange>(change);
        }
        public void UpdateInventoryList(object selectedObject)
        {
            var chip = selectedObject as ChipBase;
            if (chip == null)
            {
                return;
            }
            UpdateDropdownOptions(chip.GetNamesItem());
            SetValue(chip.GetCurrentIndex());
        }

        public void SetValue(int index)
        {
            _dropdown.value = index;
        }

        public void ClearInvenoty(object selectedObject)
        { 
            _dropdown.ClearOptions();
        }

        public void UpdateDropdownOptions(List<string> newOptions)
        {
            _dropdown.ClearOptions();
            _dropdown.AddOptions(newOptions);
        }

        public void AddOption(string newOption)
        {
            // Добавить одну новую опцию
            _dropdown.options.Add(new TMP_Dropdown.OptionData(newOption));
            _dropdown.RefreshShownValue();
        }

        public void RemoveOptionAt(int index)
        {
            if (index >= 0 && index < _dropdown.options.Count)
            {
                // Удалить опцию по индексу
                _dropdown.options.RemoveAt(index);
                _dropdown.RefreshShownValue();
            }
            else
            {
                Debug.LogWarning("Invalid index to remove option");
            }
        }
    }
}
