using Assets.Scripts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Players.Chip
{
    public class ChipAnimation : MonoBehaviour
    {
        Animator _animator;
        public void SetAnimatorController(string animatorPath)
        {
            _animator = GetComponent<Animator>();
            Stay();
            // Загружаем аниматор контроллер из ресурсов
            RuntimeAnimatorController controller = Resources.Load<RuntimeAnimatorController>(animatorPath);
            if (controller == null)
            {
                Debug.LogError("Animator Controller not found at path: " + animatorPath);
                return;
            }
            // Назначаем загруженный аниматор контроллер
            _animator.runtimeAnimatorController = controller;
        }

        public void Stay()
        {
            _animator.SetBool("Moving", false);
        }
        public void Move()
        {
            _animator.SetBool("Moving", true);
        }
        public void Attack()
        {
            _animator.SetTrigger("Attack");
        }
    }
}
