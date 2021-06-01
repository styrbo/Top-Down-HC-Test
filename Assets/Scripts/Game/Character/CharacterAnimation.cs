using UnityEngine;

namespace Game.Character
{
    [RequireComponent(typeof(Movement))]
    public class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private Movement _movement;
        private HealthDamageable _healthDamageable;
        
        private bool _alive = true;
        
        private static readonly int IsRun = Animator.StringToHash("IsRun");
        private static readonly int Death = Animator.StringToHash("Death");

        private void Awake()
        {
            _healthDamageable = GetComponent<HealthDamageable>();
            _movement = GetComponent<Movement>();
        }
        
        private void OnEnable()
        {
            _movement.OnIsMovemenentChange += OnDirectionChanged;
            _healthDamageable.OnDeath += OnPlayerDeath;
        }

        private void OnDisable()
        {
            _movement.OnIsMovemenentChange -= OnDirectionChanged;
            _healthDamageable.OnDeath -= OnPlayerDeath;
        }

        private void OnPlayerDeath()
        {
            _alive = false;
            _animator.SetBool(Death, true);
            //todo: почему-то нету анимации смерти, но зато есть параметр, лол
            print("death animation");
        }

        private void OnDirectionChanged(bool isMove)
        {
            if(_alive == false)
                return;
            
            _animator.SetBool(IsRun, isMove);
        }
    }
}