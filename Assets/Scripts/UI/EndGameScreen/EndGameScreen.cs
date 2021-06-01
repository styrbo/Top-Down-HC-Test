using Game;
using UnityEngine;

namespace UI.EndGameScreen
{
    [RequireComponent(typeof(CanvasGroup))]
    public class EndGameScreen : MonoBehaviour
    {
        [SerializeField] private DamageableBase _characterHealth;
        [SerializeField] private MaxScoreView _maxScoreView;
        
        private bool Visibility
        {
            get => _group.alpha != 1;
            set
            {
                _group.alpha = value ? 1 : 0;
                _group.interactable = value;
            }
        }
        
        private CanvasGroup _group;

        private void Awake()
        {
            _group = GetComponent<CanvasGroup>();
            Visibility = false;
        }

        private void Start()
        {
            _characterHealth.OnDeath += () =>
            {
                Visibility = true;
                _maxScoreView.UpdateText();
            };
        }
    }
}