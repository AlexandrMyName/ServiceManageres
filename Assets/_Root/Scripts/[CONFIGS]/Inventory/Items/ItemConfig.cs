using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Configs.Inventory
{
    [CreateAssetMenu(fileName = nameof(ItemConfig), menuName = "Configs/Inventory/" + nameof(ItemConfig) , order = 0)]
    internal sealed class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set;  }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; } 

      
    }
}
