using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackObject : MonoBehaviour
    {
        [SerializeField] private float _speedRate;
        private Vector3 _cachedPosition;
        private Vector2 _size;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public float LeftBorder => _cachedPosition.x - _size.x / 2;
        public float RightBorder => _cachedPosition.x + _size.x / 2;



        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _cachedPosition = transform.position;
            _size = _spriteRenderer.size;
        }
        private void OnValidate() => _spriteRenderer ??= gameObject.GetComponent<SpriteRenderer>();



        public void Move(float value)
        {
            Vector3 position = transform.position;

            position += Vector3.right  * value * _speedRate;

            if(position.x <= LeftBorder) position.x = RightBorder -(LeftBorder - position.x);
            if(position.x >= RightBorder) position.x = LeftBorder + (RightBorder - position.x);

            transform.position = position;
        }
    }
}
