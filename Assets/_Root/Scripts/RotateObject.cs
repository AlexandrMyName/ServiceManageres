using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class RotateObject : MonoBehaviour
    {
        [SerializeField] float _speed;
        void Update()
        {

            transform.Rotate(Vector3.forward * _speed);
        }
    }
}