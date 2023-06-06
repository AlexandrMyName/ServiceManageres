using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Configs.Inventory
{
    [CreateAssetMenu(fileName = nameof(ItemConfigDataSource), menuName = "Configs/Inventory/" + nameof(ItemConfigDataSource) , order = 0)]
    internal sealed class ItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private ItemConfig[] itemConfigs;
        
        public IReadOnlyList<ItemConfig> ItemConfigs => itemConfigs;
        

      
    }
}
