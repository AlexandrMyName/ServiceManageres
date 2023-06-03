using Game.Models;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UI;
using UnityEngine;

namespace Game.Logics
{
    internal class CarController : Base
    {
        private ResourcesPath _pathView = new ResourcesPath("Prefabs/Car");
        private CarView _view;

        public CarController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove)
        {
            _view = LoadView();
            WeelsController weelsCntrl = new WeelsController(leftMove, rightMove);
            AddController(weelsCntrl);
        }

       
        private CarView LoadView(Transform container = null)
        {
            GameObject prefab = ResourcesLoader.Load(_pathView);
            GameObject viewObject = Instance<CarView>.LoadToScean(prefab, container);
            AddGameObject(viewObject);
            return Instance<CarView>.GetView(viewObject);
        }
    }
}