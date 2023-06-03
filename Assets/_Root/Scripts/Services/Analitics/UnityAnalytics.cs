using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


namespace Tools.Services { 
        internal class UnityAnalytics : IAnalyticsService
        {
            public void InvokeEvent(string eventName) =>  Analytics.CustomEvent(eventName);
            public void InvokeEvent(string eventName, Dictionary<string, object> value)  => Analytics.CustomEvent(eventName, value);
            public void InvokeTransientEvent(string playerID, decimal amount, string currency) => Analytics.Transaction(playerID, amount, currency);
        }
}
