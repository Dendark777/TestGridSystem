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
        private Weapon _currentWeapon;
        private List<Weapon> _weapons = new List<Weapon>();
        public int CountItem => CountWeapon;
        public int CountWeapon => _weapons.Count;



        internal Inventory()
        {
            _weapons.Add(new Hands());
            _weapons.Add(new Carabin());
            _weapons.Add(new Pistol());

        }

        public List<string> GetNamesItem()
        {
            return _weapons.Select(i => i.ItemName).ToList();
        }

        public void SetCurrentWeapon(int index)
        {
            if (index < 0 || index >= CountWeapon)
            {
                return;
            }
            _currentWeapon = _weapons[index];
        }
        public Weapon GetCurrentWeapon()
        {
            return _currentWeapon;
        }

        public int GetCurrentIndex()
        {
            return _weapons.IndexOf(_currentWeapon);
        }
    }
}
