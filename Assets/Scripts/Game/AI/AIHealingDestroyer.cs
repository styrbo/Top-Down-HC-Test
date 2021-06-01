using UnityEngine;

namespace Game.AI
{
    public class AIHealingDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out Healing healing))
            {
                Destroy(healing.gameObject);
            }
        }
    }
}