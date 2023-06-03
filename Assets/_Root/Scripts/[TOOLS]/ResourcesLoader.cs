using Unity.VisualScripting;
using UnityEngine;

namespace Tools
{
    internal class ResourcesPath
    {
        private string path;
        public ResourcesPath(string path) => this.path = path;
        public string GetPath() => path;
        
    }
    internal static class ResourcesLoader  { public static GameObject Load(ResourcesPath path) => Resources.Load<GameObject>(path.GetPath()); }
}