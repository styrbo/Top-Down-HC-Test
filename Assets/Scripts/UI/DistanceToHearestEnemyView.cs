using System.Linq;
using Game.AI;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class DistanceToHearestEnemyView : MonoBehaviour
    {
        [SerializeField] private Transform _character;

        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _text.text = $"дистанция до ближайшего врага: {GetHearestEnemyDistance()}";
        }

        private float GetHearestEnemyDistance()
        {
            if (AIController.AllEnemy.Count == 0)
                return 0;
            
            return AIController.AllEnemy
                .Select(enemy => Vector3.Distance(_character.position, enemy.transform.position))
                .Min();
        }
    }
}