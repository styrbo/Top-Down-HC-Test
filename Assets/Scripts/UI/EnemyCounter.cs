using Game.AI;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class EnemyCounter : MonoBehaviour
    {
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            AIController.OnEnemyCountChange += UpdateText;
        }

        private void UpdateText()
        {
            _text.text = $"enemy count: {AIController.AllEnemy.Count}";
        }
    }
}