
using Game.Models;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Game.Logics
{
    internal class GameController : Base 
    {
        public GameController(Profile profile,Transform placeForUI)
        {
            var _leftMove = new SubscriptionProperty<float>();
            var _rightMove = new SubscriptionProperty<float>();

            BackGroundController _backGroundCntrl = new BackGroundController(_leftMove,_rightMove);
            AddController(_backGroundCntrl);
            InputController _inputCntrl = new InputController(_leftMove,_rightMove, new Car(20f),placeForUI);
            AddController(_inputCntrl);
            CarController _carController = new CarController(_leftMove,_rightMove);
            AddController(_carController);
            

        }
    }
}
