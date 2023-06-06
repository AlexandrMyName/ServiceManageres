using Configs;
using Configs.Inventory;
using System.Linq;
using UnityEngine;
 

namespace Tools
{
    internal class ResourcesPath
    {
        private string path;
        public ResourcesPath(string path) => this.path = path;
        public string GetPath() => path;
        
    }
    internal static class ResourcesLoader { 
        public static GameObject Load(ResourcesPath path) => Load<GameObject>(path); 
        public static TObject Load<TObject>(ResourcesPath path) where TObject : Object => Resources.Load<TObject>(path.GetPath());

        public static ItemConfig[] LoadConfigs(ResourcesPath path)
        {
            var data = Load<ItemConfigDataSource>(path);
            ItemConfig[] emptyArray = new ItemConfig[0];

           return data == null ? emptyArray : data.ItemConfigs.ToArray();
        }
        public static UpgradeItemConfig[] LoadConfigs(ResourcesPath path, bool isUpgrade = true)
        {
            var data = Load<UpgradeItemDataSource>(path);
            ItemConfig[] emptyArray = new ItemConfig[0];

            return data == null ? null : data.ItemConfigs.ToArray();
        }
    }
}