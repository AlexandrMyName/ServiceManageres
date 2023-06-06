using Game.Logics;
using Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Models;

namespace UI
{
    internal class MenuConroller : Base
    {

        private ResourcesPath _pathView = new ResourcesPath("Prefabs/Menu");
        private Menu _view;
        private Profile _profile;
        public MenuConroller(Transform placeForUI, Profile profile)
        {
            _profile = profile; 
           _view = LoadView(placeForUI);
            _view.InitStartButton(InitStart);
            _view.InitSettingtButton(InitSettings);
            _view.InitGarageButton(InitGarage);
        }
        private Menu LoadView(Transform container = null)
        {
            GameObject prefab = ResourcesLoader.Load(_pathView);
            GameObject viewObject = Instance<Menu>.LoadToScean(prefab,container);
            AddGameObject(viewObject);
            return Instance<Menu>.GetView(viewObject);
        }
        private void InitStart() => _profile._currentGameState.Value = GameState.Game;
        private void InitSettings() => _profile._currentGameState.Value = GameState.Settings;
        private void InitGarage() => _profile._currentGameState.Value = GameState.Garage;
    }
}
