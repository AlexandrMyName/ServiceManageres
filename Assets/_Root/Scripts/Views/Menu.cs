
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    internal class Menu : MonoBehaviour
    {
        [SerializeField] private Button _start;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _garage;

        public void InitStartButton(UnityAction action) => _start.onClick.AddListener(action);
        public void InitSettingtButton(UnityAction action) => _settings.onClick.AddListener(action);

        public void InitGarageButton(UnityAction action) => _garage.onClick.AddListener(action);


        private void OnDestroy()
        {
            _start.onClick.RemoveAllListeners();
            _settings.onClick.RemoveAllListeners();
            _garage.onClick.RemoveAllListeners();
        }

    }
}
