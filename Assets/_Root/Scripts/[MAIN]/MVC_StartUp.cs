using Game.Logics;
using Game.Models;
using Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Services;

namespace Game
{
    public class MVC_StartUp : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUI;
        [SerializeField] private AnalyticsManager _managerForAnalytics;
        [SerializeField] private AdvManager _managerForAdv;

        private Profile _profile;   
        private Main _mainCntrl;

        private float startSpeedCar = 1;

        void Start()
        {
            _managerForAnalytics.InvokeStartGameEvent();
            _managerForAdv.ShowFullScreenAdv();


            _profile = new Profile(GameState.Menu, startSpeedCar);
            _mainCntrl = new Main(_placeForUI, _profile);
        }
        private void OnDestroy()
        {
            _managerForAnalytics.InvokeFinishGameEvent();
            _mainCntrl?.Dispose();
        }
    }
}
