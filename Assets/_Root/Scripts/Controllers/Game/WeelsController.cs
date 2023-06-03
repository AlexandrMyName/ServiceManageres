using Game.Models;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tools;
using UI;
using UnityEngine;

namespace Game.Logics
{
    internal class WeelsController : Base
    {
        private ResourcesPath _pathView = new ResourcesPath("Prefabs/Weels");
        private WeelsView _view;
        private readonly SubscriptionProperty<float> _diff;
        public WeelsController(SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove )
        {
            _diff = new SubscriptionProperty<float>();
            _view = LoadView();
            _view.Init(_diff);
            leftMove.Subscribe(OnLeftMove);
            rightMove.Subscribe(OnRightMove);

        }
        private WeelsView LoadView(Transform container = null)
        {
            GameObject prefab = ResourcesLoader.Load(_pathView);
            GameObject viewObject = Instance<WeelsView>.LoadToScean(prefab, container);
            AddGameObject(viewObject);
            return Instance<WeelsView>.GetView(viewObject);
        }

        private void OnRightMove(float value) => _diff.Value = value;
        private void OnLeftMove(float value) => _diff.Value = value;
    }
}