using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GetToggleGroup : MonoBehaviour
    {
        [SerializeField]
        private ToggleGroup _toggleGroup;
        public ToggleGroup ToggleGroup=>_toggleGroup;
    }
}
