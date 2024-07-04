using Assets.Scripts.Items;
using Assets.Scripts.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Players.Chip
{
    public class Inventory
    {
        private List<Weapon> _items = new List<Weapon>();
        public List<Weapon> Items => _items;

        internal Inventory()
        {
            _items.Add(new Pistol());
        }

    }
}
