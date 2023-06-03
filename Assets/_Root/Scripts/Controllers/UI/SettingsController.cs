using Game.Logics;
using Game.Models;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace UI
{
    internal class SettingsController : Base
    {
       
        private ResourcesPath _pathView = new ResourcesPath("Prefabs/Settings");
        private Settings _view;
        private Profile _profile;
        public SettingsController(Transform placeForUI, Profile profile)
        {
            _profile = profile;
            _view = LoadView(placeForUI);
            _view.InitMenuButton(InitMenu);
            
        }


        private Settings LoadView(Transform container = null)
        {
            GameObject prefab = ResourcesLoader.Load(_pathView);
            GameObject viewObject = Instance<Settings>.LoadToScean(prefab, container);
            AddGameObject(viewObject);
            return Instance<Settings>.GetView(viewObject);
        }
        private void InitMenu() => _profile._currentGameState.Value = GameState.Menu;
         
    }
}