using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Services
{
    internal class AnalyticsManager : MonoBehaviour
    {
        List<IAnalyticsService> _analyticsServices;


        private void Awake() => _analyticsServices = new List<IAnalyticsService>() { new UnityAnalytics () };

        public void InvokeStartGameEvent()
        {
            foreach (var service in _analyticsServices)
                service.InvokeEvent("Start Game");
        }
        public void InvokeFinishGameEvent()
        {
            foreach (var service in _analyticsServices)
                service.InvokeEvent("Finish Game");
        }
        public void InvokeTransientEvent()
        {
            foreach (var service in _analyticsServices)
                service.InvokeTransientEvent("Start Game",14, "RUB");
        }
    }
}
