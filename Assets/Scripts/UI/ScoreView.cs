using Game;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreView : MonoBehaviour
    {
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            UpdateText(ScoreCounter.Score);
        }

        private void OnEnable()
        {
            ScoreCounter.OnScoreCountChange += UpdateText;
        }

        private void OnDisable()
        {
            ScoreCounter.OnScoreCountChange -= UpdateText;
        }

        private void UpdateText(int scoreCount)
        {
            _text.text = $"очки: {scoreCount}";
        }
    }
}