using Game;
using Game.Character;
using UnityEngine;

namespace UI
{
    public class ScoreRecorder : MonoBehaviour
    {
        [SerializeField] private HealthDamageable _characterHealth;

        private void Start()
        {
            ScoreCounter.StartRecording();
        }

        private void OnEnable()
        {
            _characterHealth.OnDeath += OnDeath;
        }
        
        private void OnDisable()
        {
            _characterHealth.OnDeath -= OnDeath;
        }

        private void OnDeath()
        {
            ScoreCounter.StopRecording();
        }
    }
}