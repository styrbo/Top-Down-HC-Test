using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

namespace Game
{
    public class CrystalSpawner : MonoBehaviour
    {
        [SerializeField] private Healing _prefab;
        [SerializeField] private int _maxCount;
        [SerializeField] private int _startCount;
        [SerializeField] private float _spawnDelay;

        [SerializeField] private LayerMask _checkLayer;
        [SerializeField] private float _checkRadius = .5f;

        [Header("Bounds")]
        [SerializeField] private Vector3 _minSpawnPoint;
        [SerializeField] private Vector3 _maxSpawnPoint;
        

        private List<Healing> _spawned = new List<Healing>();

        private IEnumerator Start()
        {
            for (int i = 0; i < _startCount; i++)
            {
                SpawnCrystal();
            }
            
            while (true)
            {
                yield return null;

                if (_spawned.Count >= _maxCount)
                {
                    continue;
                }
                
                SpawnCrystal();

                yield return new WaitForSeconds(_spawnDelay);
            }
        }

        private void SpawnCrystal()
        {
            var obj = Instantiate(_prefab, GeneratePosition(), Quaternion.identity, transform);

            _spawned.Add(obj);
            obj.OnHeal += (healable) => _spawned.Remove(obj);
        }

        private Vector3 GeneratePosition()
        {
            var pos = new Vector3(
                Range(_minSpawnPoint.x, _maxSpawnPoint.x), 
                Range(_minSpawnPoint.y, _maxSpawnPoint.y),
                Range(_minSpawnPoint.z, _maxSpawnPoint.z)
                );

            if (Physics.SphereCast(pos, _checkRadius, Vector3.zero, out var hit, 1f, _checkLayer))
            {
                return GeneratePosition();
            }

            return pos;
        }
    }
}