using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isPlaying = false;
    public bool isPaused = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AudioManager.instance.Play_BG();
    }

    public void StartGame()
    {
        isPlaying = true;
        AudioManager.instance.Play_Skate();
    }
    public void GameOver()
    {
        isPlaying = false;
        UIManager.Instance.OpenFinish_Panel();
        AudioManager.instance.Stop_BG();
        AudioManager.instance.Stop_Skate();
        AudioManager.instance.Play_GameOver();
    }
    public void Puase()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        AudioManager.instance.Stop_Skate();
    }
    public void Unpuase()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        AudioManager.instance.Play_Skate();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("SnowBoardAdvenger");
    }
}
