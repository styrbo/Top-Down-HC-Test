using System;
using System.Collections;
using UnityEngine;

namespace Game.Character
{
    [RequireComponent(typeof(Movement))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private HealthDamageable _health;

        private Movement _movement;
        private Camera _camera;
        private Coroutine _coroutine;
        private bool _isDead;

        private void Awake()
        {
            _camera = Camera.main;
            _movement = GetComponent<Movement>();
        }

        private void OnEnable()
        {
            _health.OnDeath += OnDeath;
        }

        private void OnDisable()
        {
            _health.OnDeath -= OnDeath;
        }

        private void OnDeath()
        {
            _isDead = true;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0) || _isDead)
                return;

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, Mathf.Infinity, _groundLayer))
                return;

            MovingTo(hit.point);
        }

        private void MovingTo(Vector3 point)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(MoveTo(point));
        }

        private IEnumerator MoveTo(Vector3 point)
        {
            _movement.StartMovement();
            while (Vector3.Distance(transform.position, point) > .1f)
            {
                var movementDelta = (point - transform.position).normalized;
                _movement.Direction = new Vector2(movementDelta.x, movementDelta.z);
                
                yield return null;
            }

            _movement.StopMovement();
            _coroutine = null;
        }
    }
}