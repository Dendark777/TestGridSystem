using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Items
{
    //// Делегат для функции действия предмета
    //public delegate void ItemActionDelegate();

    //// Класс, представляющий действие предмета
    //[Serializable]
    //public class ItemAction
    //{
    //    public ItemActionType actionType;
    //    public ItemActionDelegate actionFunction;
    //}

    //// Класс предмета
    //[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
    public class ItemBase
    {
        public ItemBase(string itemName, string itemDescription, ItemType itemType, ItemSize itemSize, string pathSpite)
        {
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemType = itemType;
            ItemSize = itemSize;
            Sprite = Resources.Load<Sprite>($"Sprites/{pathSpite}");
        }

        public string ItemName { get; private set; }
        public string ItemDescription { get; private set; }
        public ItemType ItemType { get; private set; }
        public ItemSize ItemSize { get; private set; }
        public Sprite Sprite { get; protected set; }
        //public List<ItemAction> itemActions = new List<ItemAction>(); // Список действий предмета



        public virtual void Use()
        {

        }

    }
}
