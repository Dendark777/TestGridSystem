using Assets.Scripts.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ChipInfoePrepareForGame : MonoBehaviour
    {
        [SerializeField]
        private Image _logo;

        private BaseParameters BaseParameters { get; set; }

        public BaseParameters GetParameters() { return BaseParameters; }

        public void SetParameters(BaseParameters parameters)
        {
            BaseParameters = parameters;
            _logo.sprite = Resources.Load<Sprite>(parameters.LogoPath);
        }
    }
}
