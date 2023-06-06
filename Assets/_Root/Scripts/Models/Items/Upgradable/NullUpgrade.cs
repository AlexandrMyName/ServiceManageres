

namespace Game.Models
{
    internal class NullUpgrade : IUpgradeHandler
    {

        public static readonly IUpgradeHandler Default = new NullUpgrade();
        public void Upgrade(IUpgradable upgradebleModel) { }
    }
}
