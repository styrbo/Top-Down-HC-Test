using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Healing : MonoBehaviour
    {
        public static List<Healing> HealsInScene = new List<Healing>();
        public static Action OnHealingCountChanged;

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

        private void OnEnable()
        {
            HealsInScene.Add(this);
            OnHealingCountChanged?.Invoke();
        }

        private void OnDisable()
        {
            HealsInScene.Remove(this);
            OnHealingCountChanged?.Invoke();
        }
    }
}