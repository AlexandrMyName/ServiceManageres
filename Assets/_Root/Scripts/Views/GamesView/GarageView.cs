using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{

    internal interface IGarageView 
    {
        void Init(UnityAction apply, UnityAction back);
        void Deinit();
    }
    public class GarageView : MonoBehaviour , IGarageView
    {
        [SerializeField] private Button _apply;
        [SerializeField] private Button _back;

        public void Deinit()
        {
            _apply.onClick.RemoveAllListeners();
            _back.onClick.RemoveAllListeners();
        }

        public void Init(UnityAction apply, UnityAction back)
        {
            _apply.onClick.AddListener(apply);
            _back.onClick.AddListener(back);
        }

        private void OnDestroy()  => Deinit();
    }
}