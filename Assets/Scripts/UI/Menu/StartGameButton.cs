using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Menu
{
    public class StartGameButton : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}