using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.AI
{
    [RequireComponent(typeof(Movement))]
    public class AIController : MonoBehaviour
    {
        public static List<AIController> AllEnemy = new List<AIController>();
        public static Action OnEnemyCountChange;
        
        [SerializeField] private float _minTimeToChangeDir, _maxTimeToChangeDir;

        private Movement _movement;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
        }

        private void Start()
        {
            ChangeDirection();
            _movement.StartMovement();
            StartCoroutine(ChangeDirectionTimer());
        }

        private void OnEnable()
        {
            AllEnemy.Add(this);
            OnEnemyCountChange?.Invoke();
        }

        private void OnDisable()
        {
            AllEnemy.Remove(this);
            OnEnemyCountChange?.Invoke();
        }

        private void ChangeDirection()
        {
            _movement.Direction = Random.insideUnitCircle;
        }

        private IEnumerator ChangeDirectionTimer()
        {
            while (true)
            {
                var time = Random.Range(_minTimeToChangeDir, _maxTimeToChangeDir);
                yield return new WaitForSeconds(time);
            
                ChangeDirection();
            }
        }
    }
}