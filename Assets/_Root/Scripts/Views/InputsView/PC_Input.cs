
using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    internal class PC_Input : BaseInputView
    {
        [SerializeField] private float _sensitivity = 0.05f;


        private void Start() => UpdateManager.SubscribeToUpdate(Move);
        private void OnDestroy() => UpdateManager.UnsubscribeFromUpdate(Move);


        private void Move()
        {
            
            float horizontal = Input.GetAxis("Horizontal");
            float moveValue = _speed * _sensitivity * Time.deltaTime * horizontal;
            if (horizontal > 0 ) OnRightMove(moveValue);
            else if(horizontal < 0) OnLeftMove(moveValue);
 
        }


    }
}
