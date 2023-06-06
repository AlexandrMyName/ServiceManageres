using Configs.Inventory;
using Game.Models;
using Game.Models.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logics
{
    internal interface IItemRepository
    {
        IReadOnlyDictionary<string, IItem>  Items { get; }
    }
    internal class ItemRepository : BaseRepository<string, IItem, ItemConfig>, IItemRepository
    {
        public ItemRepository(IEnumerable<ItemConfig> configs) : base(configs)
        {

        }

        protected override IItem CreateItem(ItemConfig config)
        {
            return new Item(config.Id, new ItemInfo(config.Title, config.Icon));
        }

        protected override string GetKey(ItemConfig config) =>  config.Id;
         
    }
}