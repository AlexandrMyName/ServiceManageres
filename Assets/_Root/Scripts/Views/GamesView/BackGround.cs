using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace UI
{
    internal class BackGround : MonoBehaviour
    {
        [SerializeField] private BackObject[] _backObjects;

        private IReadOnlySubscriptionProperty<float> _diff;

        public void Init(IReadOnlySubscriptionProperty<float> diff)
        {
            _diff = diff;
            _diff.Subscribe(Move);
        }
        private void OnDestroy() => _diff?.Unsubscribe(Move);
        
        private void Move(float value)
        {
         
            foreach(var obj in _backObjects)
                obj.Move(-value);
        }
    }
}
