using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public event Action<Vector2> OnDirectionChanged;
        public event Action<bool> OnIsMovemenentChange;

        public bool IsMoving => _coroutine != null;
        
        public Vector2 Direction
        {
            get => _direction;
            set
            {
                if(value == _direction)
                    return;
                
                OnDirectionChanged?.Invoke(value);
                _direction = value;
            }
        }

        private Rigidbody _rb;
        private Vector2 _direction;
        private Coroutine _coroutine;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void StartMovement()
        {
            if(_coroutine != null)
                return;
            
            _coroutine = StartCoroutine(Move());
            OnIsMovemenentChange?.Invoke(true);
        }

        public void StopMovement()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
                OnIsMovemenentChange?.Invoke(false);
            }
        }

        private IEnumerator Move()
        {
            while (true)
            {
                var direction = new Vector3(Direction.x, 0, Direction.y);
                _rb.MovePosition(_rb.position + direction * (_speed * Time.fixedDeltaTime));
                yield return new WaitForFixedUpdate();
            }
        }
    }
}