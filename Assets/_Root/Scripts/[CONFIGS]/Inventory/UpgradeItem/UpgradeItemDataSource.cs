using Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(UpgradeItemDataSource), menuName = "Configs/Inventory/" + nameof(UpgradeItemDataSource), order = 0)]
    internal class UpgradeItemDataSource : ScriptableObject
    {
        [SerializeField] private UpgradeItemConfig[] _configs;


        public IReadOnlyList<UpgradeItemConfig> ItemConfigs => _configs;
    }
}