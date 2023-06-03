using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Logics
{
    internal abstract class Base : IDisposable
    {
        private List<GameObject> _gameobjects;
        private List<Base> _controllers;

        
        public void Dispose()
        {
            if(_controllers != null)
                 foreach(var controller in _controllers)
                        controller?.Dispose();
            if (_gameobjects != null)
                 foreach (var gameobject in _gameobjects)
                         GameObject.Destroy(gameobject);

            _gameobjects?.Clear();
            _controllers?.Clear();
            OnDisposable();
        }

        public virtual void OnDisposable() { }

        protected void AddGameObject(GameObject gameobject)
        {
            if (_gameobjects == null)
                _gameobjects = new List<GameObject>();

            _gameobjects.Add(gameobject);
        }
        protected void AddController(Base controller)
        {
            if(_controllers == null) 
                _controllers = new List<Base>();

            _controllers.Add(controller);
        }

    }
}

