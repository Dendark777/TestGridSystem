﻿using System;
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
        public Pistol() : base("Пистолет", "dsa", ItemType.Weapon, ItemSize.Small, "Pistol")
        {
        }

    }
}
