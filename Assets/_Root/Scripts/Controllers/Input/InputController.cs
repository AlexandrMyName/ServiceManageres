using Game.Models;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Logics
{
    internal class InputController : Base
    {
        private ResourcesPath _pathView = new ResourcesPath("Prefabs/Tap_Input");
        private BaseInputView _view;

        public InputController(SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove, Car car, Transform placeForUI = null)
        {
            _view = LoadView(placeForUI);
            _view.Init(leftMove,rightMove, car.GetSpeed());
             
        }
        private BaseInputView LoadView(Transform container = null)
        {
            GameObject prefab = ResourcesLoader.Load(_pathView);
            GameObject viewObject = Instance<BaseInputView>.LoadToScean(prefab, container);
            AddGameObject(viewObject);
            return Instance<BaseInputView>.GetView(viewObject);
        }
    }
}
