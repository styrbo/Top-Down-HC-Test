using System.Collections;
using UnityEngine;

namespace Game.AI
{
    public class AISpawner : MonoBehaviour
    {
        [SerializeField] private int _maxAliveCount;
        [SerializeField] private float _spawnDelay;
        
        [SerializeField] private DamageableBase _prefab;

        private int _currentAliveCount;

        private void OnEnable()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);
                
                if(_maxAliveCount <= _currentAliveCount)
                    continue;

                var newInstance = Instantiate(_prefab, transform.position, Quaternion.identity, transform);

                newInstance.OnDeath += DecreaseAliveCount; 
                
                _currentAliveCount++;
            }

            void DecreaseAliveCount()
            {
                _currentAliveCount--;
            }
        }
    }
}