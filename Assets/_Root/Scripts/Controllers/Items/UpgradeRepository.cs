using Configs;
using Configs.Inventory;
using Game.Models;
using System.Collections.Generic;
 

namespace Game.Logics
{
    internal interface IUpgradeHandlerRepository { IReadOnlyDictionary<string, IUpgradeHandler> Handlers { get; } }

    internal class UpgradeRepository : BaseRepository<string, IUpgradeHandler, UpgradeItemConfig> ,IUpgradeHandlerRepository
    {
        public UpgradeRepository(IEnumerable<UpgradeItemConfig> configs) : base(configs) { }
        public IReadOnlyDictionary<string, IUpgradeHandler> Handlers => throw new System.NotImplementedException();
 
        protected override IUpgradeHandler CreateItem(UpgradeItemConfig config) =>
              config.Type switch
              {
                  UpgradeType.Speed => new SpeedUpgradeHandler(config.Value),
                  _ => NullUpgrade.Default 

              };
        protected override string GetKey(UpgradeItemConfig config) => config.Id;
    }
}