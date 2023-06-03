using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    internal class Settings : MonoBehaviour
    {
        [SerializeField] private Button _menuButton;


        public void InitMenuButton(UnityAction action) => _menuButton.onClick.AddListener(action);


        private void OnDestroy()
        {
            _menuButton.onClick.RemoveAllListeners();
        }
    }
}
