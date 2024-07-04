using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Items
{
    public enum ItemSize
    {
        None,
        Small,
        Large,
    }
    // Перечисление для определения типа предмета
    public enum ItemType
    {
        Weapon,
        Tool,
        Consumable,
        Other
    }

    // Перечисление для возможных действий предмета
    public enum ItemActionType
    {
        Attack,
        Use,
        Equip,
        Other
    }
}
