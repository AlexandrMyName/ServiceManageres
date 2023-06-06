using Configs;
using Game.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UI;
using UnityEngine;

namespace Game.Logics
{
    internal class GarageController : Base
    {
        private ResourcesPath _pathView = new ResourcesPath("Prefabs/Inventory/GarageView");
        private ResourcesPath _dataSourcePath = new ResourcesPath("Configs/Items/UpgradeItems/UpgradeItemDataSource");

        private GarageView _view;
        private Profile _profile;

        private InventoryController _inventoryController;

        private UpgradeRepository _upgradeRepository;


        public GarageController(Transform placeForUI, Profile profile)
        {
            _profile = profile;
            _upgradeRepository = CreateRepository(placeForUI);
            
            _inventoryController = CreateInventoryController(placeForUI);
            _view = LoadView(placeForUI);
            _view.Init(Apply,Back);
        }

        private void UpgradeWithEquieppedItems(
            IUpgradable upgradble,
            IReadOnlyList<string> upgradeItems,
            IReadOnlyDictionary<string,IUpgradeHandler> upgradeHanler
            )
        {
            foreach(string Itemid in upgradeItems)
            {
                if(upgradeHanler.TryGetValue(Itemid, out IUpgradeHandler handler))
                {
                    handler.Upgrade(upgradble);
                }
            }
        }
        private void Apply()
        {
           
            _profile._car.Restore();

            UpgradeWithEquieppedItems(_profile._car,_profile._inventory.Equippeditems, _upgradeRepository.Items);
            Debug.Log("Current Speed (Apply method):" + _profile._car.Speed);
            _profile._currentGameState.Value = GameState.Menu;
        }
        private void Back()
        {
            Debug.Log("Current Speed (Back method):" + _profile._car.Speed);
            _profile._currentGameState.Value = GameState.Menu;
        }
        private InventoryController CreateInventoryController(Transform placeForUI)
        {
            var inventoryCntrl = new InventoryController(placeForUI, _profile._inventory);
            
            AddController(inventoryCntrl);
            return inventoryCntrl;
        }

        private UpgradeRepository CreateRepository(Transform placeForUI)
        {
            UpgradeItemConfig[] configs = ResourcesLoader.LoadConfigs(_dataSourcePath,true); 
            var repository = new UpgradeRepository(configs);
            AddRepository(repository);
            return repository;
        }

        private GarageView LoadView(Transform container = null)
        {
            GameObject prefab = ResourcesLoader.Load(_pathView);
            GameObject viewObject = Instance<GarageView>.LoadToScean(prefab, container);
            AddGameObject(viewObject);
            return Instance<GarageView>.GetView(viewObject);
        }
    }
}