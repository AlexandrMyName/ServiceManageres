using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Tools
{
    internal class SubscriptionProperty<T> : IReadOnlySubscriptionProperty<T>
    {
        private Action<T> action;
        private T _value;
        public T Value
        {

            get => _value;

            set {
                _value = value;
                action?.Invoke(_value);
            }
        }

        public void Subscribe(Action<T> method) => action += method;
        

        public void Unsubscribe(Action<T> method) => action -= method;
        
    }
}