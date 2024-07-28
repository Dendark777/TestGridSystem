using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ColorPicker : MonoBehaviour
    {
        public Image selectedColorDisplay;
        public Slider redSlider;
        public Slider greenSlider;
        public Slider blueSlider;

        private void Start()
        {
            // Установка слушателей для изменения значений слайдеров
            redSlider.onValueChanged.AddListener(UpdateColor);
            greenSlider.onValueChanged.AddListener(UpdateColor);
            blueSlider.onValueChanged.AddListener(UpdateColor);

            // Инициализация цвета
            UpdateColor();
        }

        private void UpdateColor(float value = 0)
        {
            // Получение значений слайдеров
            float red = redSlider.value / 255f;
            float green = greenSlider.value / 255f;
            float blue = blueSlider.value / 255f;

            // Установка цвета
            Color color = new Color(red, green, blue);
            selectedColorDisplay.color = color;
        }

        public Color GetColor()
        {
            return selectedColorDisplay.color;
        }
    }
}
