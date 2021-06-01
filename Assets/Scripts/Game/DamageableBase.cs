using System;
using UnityEngine;

namespace Game
{
    public abstract class DamageableBase : MonoBehaviour
    {
        public abstract event Action OnDeath;

        public abstract void TakeDamage();
    }

    public interface IHealable
    {
        void Heal();
    }
}