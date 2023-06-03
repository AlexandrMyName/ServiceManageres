using Game.Models;

using Tools;
using UI;
using UnityEngine;
using UnityEngine.Profiling;

namespace Game.Logics
{
    internal class Main : Base
    {

        private MenuConroller _menuCntrl;
        private SettingsController _settingsController;
        private GameController _gameController;
        private Transform _placeForUI;
        private Profile _profile;

        public Main(Transform placeForUI, Profile profile)
        {
            _profile = profile;
            _placeForUI = placeForUI;
            _profile._currentGameState.Subscribe(OnChangeGameState);
            OnChangeGameState(_profile._currentGameState.Value);
        }

        public override void OnDisposable()
        {
          _menuCntrl?.Dispose();
        }



        public void OnChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Menu:
                    _menuCntrl = new MenuConroller(_placeForUI, _profile);
                    _settingsController?.Dispose();
                    _gameController?.Dispose();
                        break;

                case GameState.Settings:
                    Debug.Log("To Settings ");
                    _settingsController = new SettingsController(_placeForUI, _profile);
                    _menuCntrl?.Dispose();
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _gameController = new GameController(_profile,_placeForUI);
                    _menuCntrl?.Dispose();
                    _settingsController?.Dispose();
                        break;

                    default:
                    _menuCntrl?.Dispose();
                    _settingsController?.Dispose();
                    _gameController?.Dispose();
                    break;

            }
        }
    }
}
