using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        HighScoreManager.Instance.GetUserName();
        SceneManager.LoadScene(1);
    }
}
