using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Items.Weapons
{
    public class Pistol : Weapon
    {
        public Pistol() 
        {
            Sprite = Resources.Load<Sprite>("Images/Weapons/Pistol");
        }
    }
}
