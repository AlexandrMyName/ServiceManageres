using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Models
{
    internal interface IRepository : IDisposable { }

    internal abstract class BaseRepository<Tkey, Tvalue, Tconfig> : IRepository 
    {
        private Dictionary<Tkey, Tvalue> _items;

        public IReadOnlyDictionary<Tkey, Tvalue> Items => _items;

        protected BaseRepository(IEnumerable<Tconfig> configs) => _items = CreateItems(configs);

        private Dictionary<Tkey, Tvalue> CreateItems(IEnumerable<Tconfig> configs)
        {
            var items = new Dictionary<Tkey, Tvalue>();
            foreach (var config in configs)
            {
                items[GetKey(config)] = CreateItem(config);
            }
            return items;
        }

        protected abstract Tkey GetKey(Tconfig config);

        protected abstract Tvalue CreateItem(Tconfig config);

        public void Dispose() => _items.Clear();
    }
}
