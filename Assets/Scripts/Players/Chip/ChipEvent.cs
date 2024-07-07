using Assets.Scripts.Players.Chip.ChipEvents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            EventBus.Instance.Publish<ChipSelectedEvent>(_chip);
        }
        public void Deselected()
        {
            EventBus.Instance.Publish<ChipDeselectedEvent>(_chip);
        }
    }
}
