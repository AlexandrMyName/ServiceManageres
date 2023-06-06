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
        void Start()
        {
            //Интерфейс заглушки не реализовал из за нехватки времени , но вся суть думаю сделана
            //Колбэк функции рекламы пока только выражаются в отладке
            //Так же добавил контроллер для вращения колес
            //К сожалению Аналитика для Юнити так и не заработала , возможно надо подождать, ID все зависимости разрешил
            _managerForAnalytics.InvokeStartGameEvent();
            _managerForAdv.ShowFullScreenAdv();


            _profile = new Profile(GameState.Menu,1);
            _mainCntrl = new Main(_placeForUI, _profile);
        }
        private void OnDestroy()
        {
            _managerForAnalytics.InvokeFinishGameEvent();
            _mainCntrl?.Dispose();

        }
    }
}
