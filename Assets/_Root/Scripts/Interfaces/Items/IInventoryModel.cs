 
using System.Collections.Generic;
 

namespace Game.Models
{
    internal interface IInventoryModel  
    {
        IReadOnlyList<string> Equippeditems { get; }
        void EquipItem(string itemId);
        void UnequipItem(string itemId);
        bool IsEquipped(string itemId);
    }
}
