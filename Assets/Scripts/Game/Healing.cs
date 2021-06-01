using System;
using UnityEngine;

namespace Game
{
    public class Healing : MonoBehaviour
    {
        public Action<IHealable> OnHeal;

        private IHealable _healable;

        private void OnTriggerEnter(Collider other)
        {
            if(!other.TryGetComponent(out IHealable damageable))
                return;
            
            damageable.Heal();
            OnHeal?.Invoke(_healable);
            Destroy(gameObject);
        }
    }
}