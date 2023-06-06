using Configs.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(UpgradeItemConfig) , menuName = "Configs/Inventory/" + nameof(UpgradeItemConfig), order = 0)]
    internal class UpgradeItemConfig : ScriptableObject
    {
        [SerializeField] private ItemConfig _config;
        [field: SerializeField] public float Value { get; private set; }
        [field: SerializeField] public UpgradeType Type { get; private set; }


        public string Id => _config.Id;
    }

    public enum UpgradeType { None, Speed }
}