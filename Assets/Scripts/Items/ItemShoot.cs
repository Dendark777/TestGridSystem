﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class ItemShoot : IItemAction
    {
        public void ItemAction()
        {
            Debug.Log("Выстрел");
        }
    }
}
