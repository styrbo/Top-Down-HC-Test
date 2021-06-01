using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Healing))]
    public class GiveScoreByHeal : MonoBehaviour
    {
        [SerializeField] private int _count;

        private Healing _healing;

        private void Awake()
        {
            _healing = GetComponent<Healing>();
            _healing.OnHeal += (healable) => GiveScore();
        }

        private void GiveScore()
        {
            ScoreCounter.AddScore(_count);
        }
    }
}