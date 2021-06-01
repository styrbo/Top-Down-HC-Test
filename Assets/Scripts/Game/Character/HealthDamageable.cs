using System;
using UnityEngine;

namespace Game.Character
{
    public class HealthDamageable : DamageableBase, IHealable
    {
        public Action<int> OnHpChange;
        
        [SerializeField] private int _maxHP = 3;

        private int _hp;

        public int MaxHP => _maxHP;
        public int HP => _hp;

        private void Awake()
        {
            _hp = _maxHP;
        }

        public override event Action OnDeath;
        
        public override void TakeDamage()
        {
            _hp--;
            OnHpChange?.Invoke(_hp);
            
            if(_hp <= 0)
                OnDeath?.Invoke();
        }

        public void Heal()
        {
            _hp = _maxHP;
            OnHpChange?.Invoke(_hp);
        }
    }
}