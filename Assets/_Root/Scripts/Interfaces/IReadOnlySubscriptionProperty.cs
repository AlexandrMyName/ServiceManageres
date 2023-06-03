using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    internal interface IReadOnlySubscriptionProperty <out T>
    {

         T Value { get; }

        void Subscribe(Action<T> method);
        void Unsubscribe(Action<T> method);
    }
}