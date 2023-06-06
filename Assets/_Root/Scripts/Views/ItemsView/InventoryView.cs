using Game.Models.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    internal class InventoryView : MonoBehaviour 
    {
        [SerializeField] private GameObject _itemViewPrefab;
        [SerializeField] private Transform _placeForItems;

        private readonly Dictionary<string, ItemView> _itemViews = new Dictionary<string, ItemView>();

        public void Display(IEnumerable<IItem> itemsCollection, Action<string> itemClicked)
        {
            Clear();

            foreach(var itemCnf in itemsCollection)
            
                _itemViews[itemCnf.Id] = CreateItemView( itemCnf, itemClicked);
            
        }

        private ItemView CreateItemView(IItem item, Action<string> itemClicked)
        {
            GameObject itemObject = Instantiate(_itemViewPrefab, _placeForItems);
            ItemView itemView = itemObject.GetComponent<ItemView>();
            itemView.Init(item, () => itemClicked?.Invoke(item.Id));

            return itemView;
        }

        public void Clear()
        {
            foreach(var itemView in _itemViews.Values)
                DestroyItemView(itemView);
            
            _itemViews.Clear();
        }

        private void DestroyItemView(ItemView itemView)
        {
            itemView.DeInit();
            Destroy(itemView.gameObject);
        }

        public void Select(string id) => _itemViews[id].Select();
        public void Unselect(string id) => _itemViews[id].Unselect();
    }
}