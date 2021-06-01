using System;
using System.Collections;
using UnityEngine;

namespace Game.Character
{
    public class InvincibleFrames : DamageableBase, IHealable
    {
        [SerializeField] private float _duration;
        [SerializeField] private DamageableBase _damageable;

        private bool _canTakeDamage = true;

        private void OnEnable()
        {
            _damageable.OnDeath += Death;
        }

        private void OnDisable()
        {
            _damageable.OnDeath -= Death;
        }

        private void Death() => OnDeath?.Invoke();

        public override event Action OnDeath;
        public override void TakeDamage()
        {
            if(_canTakeDamage == false)
                return;

            StartCoroutine(InvincibleTimer());
            _damageable.TakeDamage();
        }

        public void Heal()
        {
            var healable = _damageable as IHealable;

            healable?.Heal();
        }

        private IEnumerator InvincibleTimer()
        {
            _canTakeDamage = false;
            yield return new WaitForSeconds(_duration);
            _canTakeDamage = true;
        }
    }
}