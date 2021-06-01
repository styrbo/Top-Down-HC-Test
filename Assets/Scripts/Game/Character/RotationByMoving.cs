using UnityEngine;

namespace Game.Character
{
    [RequireComponent(typeof(Movement))]
    public class RotationByMoving : MonoBehaviour
    {
        [SerializeField] private Transform _rotationRoot;
        
        private Movement _movement;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
        }

        private void OnEnable()
        {
            _movement.OnDirectionChanged += OnDirectionChanged;
        }

        private void OnDisable()
        {
            _movement.OnDirectionChanged -= OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector2 direction)
        {
            if(_movement.IsMoving == false)
                return;
            
            _rotationRoot.forward = new Vector3(direction.x, 0, direction.y);
        }
    }
}