using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverPanel;
    public TMP_Text finalScore;

    private bool isGameOver = false;
    public bool IsGameOver => isGameOver;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        DropManager.Instance.StopDropping();
        SoundManager.Instance.PlayBGM();
        finalScore.text = "FINAL SCORE\n" + ScoreManager.Instance.CurrentScore;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void GoToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

}
