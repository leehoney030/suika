using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;
    public int[] mergeScores = {1,2,4,8,16,32,64,128,256,512,1024,2048};

    private int currentScore = 0;
    public int CurrentScore => currentScore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int level)
    {
        currentScore += mergeScores[level];

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "SCORE\n" + currentScore;
    }
}
