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
        [SerializeField]
        Animator Animator;

        public void Start() 
        {
            Animator = GetComponent<Animator>();
            Stay();
        }
        public void Stay()
        {
            Animator.SetBool("Moving", false);
        }
        public void Move()
        {
            Animator.SetBool("Moving", true);
        }
        public void Attack()
        {
            Animator.SetTrigger("Attack");
        }
    }
}
