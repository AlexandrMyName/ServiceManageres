using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace UI
{
    internal class WeelsView : MonoBehaviour
    {
        [SerializeField] private GameObject [] _weels;
        [SerializeField] private float _speedWeel = 1f;
        private IReadOnlySubscriptionProperty<float> _diff;

         
        public void Init(SubscriptionProperty<float> diff)
        {
            _diff = diff;
            _diff.Subscribe(Rotate);
        }
        private void OnDestroy() => _diff.Unsubscribe(Rotate);
        
        private void Rotate(float value)
        {
            
            foreach (var weel in _weels)
                weel.transform.Rotate(Vector3.forward  * _speedWeel * (value > 0 ? -1 : 1));
             
 
        }
    }
}