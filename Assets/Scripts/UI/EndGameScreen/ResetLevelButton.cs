using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.EndGameScreen
{
    public class ResetLevelButton : MonoBehaviour
    {
        public void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}