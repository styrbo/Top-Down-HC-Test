using Game.AI;
using UnityEngine;

namespace Game.Character
{
    public class CharacterCollision : MonoBehaviour
    {
        [SerializeField] private DamageableBase _playerDamageble;
        
        private void OnCollisionStay(Collision other)
        {
            if(!other.transform.TryGetComponent(out AIController enemy))
                return;
            
            _playerDamageble.TakeDamage();
        }
    }
}