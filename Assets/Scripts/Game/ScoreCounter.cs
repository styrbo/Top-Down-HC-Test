using System;
using UnityEngine;

namespace Game
{
    public static class ScoreCounter
    {
        public static Action<int> OnScoreCountChange;
        
        public static int MaxScore
        {
            get => PlayerPrefs.GetInt(_scoreSavingKey, 0);
            set => PlayerPrefs.SetInt(_scoreSavingKey, value);
        }

        public static int Score { get; private set; }

        private const string _scoreSavingKey = "MaxScore";
        
        public static void StartRecording()
        {
            Score = 0;
        }

        public static void StopRecording()
        {
            if (Score > MaxScore)
            {
                MaxScore = Score;
            }
        }
        
        public static void AddScore(int count)
        {
            Score += count;
            OnScoreCountChange?.Invoke(Score);
        }
    }
}