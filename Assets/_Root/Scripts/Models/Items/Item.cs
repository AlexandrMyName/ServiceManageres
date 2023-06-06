using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Models.Items
{

    internal interface IItem
    {
        string Id { get; }
        ItemInfo Info { get; }
    }
    internal readonly struct ItemInfo
    {
        public ItemInfo(string title, Sprite icon)
        {
            Title = title;
            Icon = icon;
        }
        public string Title { get;   }
        public Sprite Icon { get;  }

       

    }
    internal class Item : IItem
    {
        public string Id { get; }

        public ItemInfo Info { get; }

        public Item(string id, ItemInfo info)
        {
            Id = id;
            Info = info;
        }
    }
}