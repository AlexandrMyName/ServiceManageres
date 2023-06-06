using Game.Models;
using JetBrains.Annotations;
using System.Linq;
using Tools;
using UI;
using UnityEngine;
 
 

namespace Game.Logics
{
    internal class InventoryController : Base
    {
        private ResourcesPath _pathView = new ResourcesPath("Prefabs/Inventory/InventoryView");
        private ResourcesPath _dataSourcePath = new ResourcesPath("Configs/Items/ItemConfigDataSource");

        private readonly InventoryView _view;
        private IInventoryModel _model;
        private ItemRepository _itemRepository;

        public InventoryController([NotNull] Transform placeForUI,   IInventoryModel inventoryModel)
        {
            _model = inventoryModel;
            _itemRepository = CreateRepository();
            _view = CreateView(placeForUI);
            _view.Display(_itemRepository.Items.Values  , OnItemClicked);
           
                foreach (string itemId in _model.Equippeditems)
                {
                    _view.Select(itemId);
                }
            
        }

        private ItemRepository CreateRepository()
        {
            var itemConfigs = ResourcesLoader.LoadConfigs(_dataSourcePath);
            var repository = new ItemRepository(itemConfigs);
            AddRepository(repository);
            return repository;
        }

        private InventoryView CreateView(Transform container = null)
        {
            GameObject prefab = ResourcesLoader.Load(_pathView);
            GameObject viewObject = Instance<InventoryView>.LoadToScean(prefab, container);
            AddGameObject(viewObject);
            return Instance<InventoryView>.GetView(viewObject);
        }

        private void OnItemClicked(string itemId)
        {
           bool isEquipped =  _model.IsEquipped(itemId);
            if (isEquipped)
            {
                 UnequipItem(itemId);
            }
            else
            {
                 EquipItem(itemId);
            }
        }

        private void UnequipItem(string itemID)
        {
            _view.Unselect(itemID);
            _model.UnequipItem(itemID);
        }
        private void EquipItem(string itemID)
        {
            _view.Select(itemID);
            _model.EquipItem(itemID);
        }
    }
}