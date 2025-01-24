using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    [SerializeField] private TMP_InputField inputField;

    [HideInInspector]
    public string userName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GetUserName()
    {
        userName = inputField.text;
    }

    public void StartGame()
    {
        GetUserName();
        SceneManager.LoadScene(1);
    }
}
