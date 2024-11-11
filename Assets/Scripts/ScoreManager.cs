using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UIManager.Instance.UpdateScoreText(score);
    }
    public void GetScore() 
    {
        score += 1;
        UIManager.Instance.UpdateScoreText(score);
        AudioManager.instance.Play_Score();
    }
}
