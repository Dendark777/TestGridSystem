using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Players
{
    internal class HumanController : MonoBehaviour
    {
        private Human human; // Ссылка на компонент человека

        void Start()
        {
            human = GetComponent<Human>(); // Получаем компонент человека
        }

        void Update()
        {
            // Проверяем возможность совершения действий
            if (human.numActions > 0 && human.isConscious)
            {
                // Обработка ввода для перемещения
                if (Input.GetKeyDown(KeyCode.W))
                {
                    // Движение вверх
                    human.Move(transform.position + Vector3.up);
                    human.numActions--;
                }
                // Проверяем остальные действия и обрабатываем ввод пользователя
            }
        }
    }
}
