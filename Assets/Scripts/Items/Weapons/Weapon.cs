using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items.Weapons
{
    public class Weapon : ItemBase
    {
        public Weapon(string itemName, string itemDescription, ItemType itemType, ItemSize itemSize, string pathSpite) 
            : base(itemName, itemDescription, itemType, itemSize, $"Weapons/{pathSpite}")
        {
        }

        public virtual void Shoot()
        {
            
        }
    }
}
