using Game;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class MaxScoreView : MonoBehaviour
    {
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        public void UpdateText()
        {
            _text.text = $"рекорд: {ScoreCounter.MaxScore}";
        }
    }
}