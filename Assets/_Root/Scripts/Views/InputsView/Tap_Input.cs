using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class Tap_Input : BaseInputView
    {
        [SerializeField] private float _sensitivity = 0.05f;
        

        private float mainValue;

        private void Start()
        {
            UpdateManager.SubscribeToUpdate(Move);

         
             
        }
        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);

           
        }


        private void Move()
        {
            float moveValue = _speed * _sensitivity * Time.deltaTime * mainValue;
            if (mainValue > 0) OnRightMove(moveValue);
            else if (mainValue < 0) OnLeftMove(moveValue);
        }
        public void RessetTap() => mainValue = 0f;
         
        public void LeftTap() => mainValue = -1f;
        public void RightTap() => mainValue = 1f;
       
    }
}