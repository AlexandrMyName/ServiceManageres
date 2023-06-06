using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Models
{
    internal class Inventory : IInventoryModel
    {
        
        private readonly List<string> _equieppedItems = new List<string>(); 
        IReadOnlyList<string> IInventoryModel.Equippeditems => _equieppedItems;

        public bool IsEquipped(string itemId) =>_equieppedItems.Contains(itemId);
       

        public void EquipItem(string itemId)
        {
           if(!IsEquipped(itemId))
                _equieppedItems.Add(itemId);
        }
        
        public void UnequipItem(string itemId)
        {
            if (!IsEquipped(itemId)) return;
                _equieppedItems.Remove(itemId);


             
        }
    }
}
