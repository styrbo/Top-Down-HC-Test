using Game.Character;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class PlayerHealView : MonoBehaviour
    {
        [SerializeField] private HealthDamageable _characterHeal;

        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            UpdateText(_characterHeal.HP);
            _characterHeal.OnHpChange += UpdateText;
        }

        private void OnDestroy()
        {
            _characterHeal.OnHpChange -= UpdateText;
        }

        private void UpdateText(int healCount)
        {
            _text.text = $"хп: {healCount}/{_characterHeal.MaxHP}";
        }
    }
}