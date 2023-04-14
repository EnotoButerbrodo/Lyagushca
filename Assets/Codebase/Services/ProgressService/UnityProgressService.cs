using UnityEngine;

namespace Lyaguska.Services
{
    public class UnityProgressService : IProgressService
    {
        private const string HighScoreKey = "HighScore";
        
        public int GetHighScore()
        { 
            return PlayerPrefs.GetInt(HighScoreKey, defaultValue: 0);
        }

        public void UpdateHighScore(int score)
        {
            bool isNewHighScore = score > GetHighScore();
            if (isNewHighScore)
            {
                PlayerPrefs.SetInt(HighScoreKey, score);
                PlayerPrefs.Save();
            }
        }
    }
}