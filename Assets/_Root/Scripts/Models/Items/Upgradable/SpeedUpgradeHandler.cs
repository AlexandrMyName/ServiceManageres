

namespace Game.Models
{
    internal class SpeedUpgradeHandler : IUpgradeHandler
    {
        private readonly float _speed;

        public SpeedUpgradeHandler(float speed ) => _speed = speed;
        public void Upgrade(IUpgradable upgradebleModel) => upgradebleModel.Speed += _speed;
       
    }
}
