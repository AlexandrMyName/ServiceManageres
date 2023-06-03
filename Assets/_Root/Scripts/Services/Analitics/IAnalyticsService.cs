using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Services
{
    internal interface IAnalyticsService 
    {
        void InvokeEvent(string eventName);
        void InvokeEvent(string eventName, Dictionary<string,object > value );
        void InvokeTransientEvent(string playerID, decimal amount, string currency);
    }
}
