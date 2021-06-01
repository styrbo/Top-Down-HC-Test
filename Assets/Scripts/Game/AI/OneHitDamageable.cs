using System;
using UnityEngine;

namespace Game.AI
{
    public class OneHitDamageable : DamageableBase
    {
        public override event Action OnDeath;
        
        public override void TakeDamage()
        {
            OnDeath?.Invoke();
        }

        public void Heal()
        {
            
        }
    }
}