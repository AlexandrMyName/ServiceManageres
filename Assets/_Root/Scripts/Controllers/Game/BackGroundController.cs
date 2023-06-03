using System.Collections;
using System.Collections.Generic;
using Tools;
using UI;
using UnityEngine;

namespace Game.Logics
{
    internal class BackGroundController : Base
    {
        private ResourcesPath _pathView = new ResourcesPath("Prefabs/BackGround");
        private BackGround _view;
        private readonly SubscriptionProperty<float> _leftMove;
        private readonly SubscriptionProperty<float> _rightMove;
        private readonly SubscriptionProperty<float> _diff;
        public BackGroundController(SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            _diff = new SubscriptionProperty<float>();
            _view = LoadView();
            _view.Init(_diff);
            _leftMove.Subscribe(MoveLeft);
            _rightMove.Subscribe(MoveRight);
        }

        public override void OnDisposable()
        {
            _leftMove.Unsubscribe(MoveLeft);
            _rightMove.Unsubscribe(MoveRight);
        }
        private BackGround LoadView(Transform container = null)
        {
            GameObject prefab = ResourcesLoader.Load(_pathView);
            GameObject viewObject = Instance<BackGround>.LoadToScean(prefab, container);
            AddGameObject(viewObject);
            return Instance<BackGround>.GetView(viewObject);
        }

        private void MoveRight(float value) => _diff.Value = value;
        private void MoveLeft(float value) => _diff.Value = value;
    }
}
