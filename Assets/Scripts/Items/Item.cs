using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
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

    // Делегат для функции действия предмета
    public delegate void ItemActionDelegate();

    // Класс, представляющий действие предмета
    [Serializable]
    public class ItemAction
    {
        public ItemActionType actionType;
        public ItemActionDelegate actionFunction;
    }

    // Класс предмета
    [CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public string itemDescription;
        public ItemType itemType;
        public List<ItemAction> itemActions = new List<ItemAction>(); // Список действий предмета

        // Добавление действия в список действий предмета
        public void AddAction(ItemActionType actionType, ItemActionDelegate actionFunction)
        {
            itemActions.Add(new ItemAction { actionType = actionType, actionFunction = actionFunction });
        }
    }
}
