using Game;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class CrystalCounter : MonoBehaviour
    {
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            Healing.OnHealingCountChanged += UpdateText;
            UpdateText();
        }

        private void UpdateText()
        {
            _text.text = $"crystals count: {Healing.HealsInScene.Count}";
        }
    }
}