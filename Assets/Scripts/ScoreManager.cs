using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int leftScore;
    public int rightScore;

    [SerializeField] private int maxScore;
    [SerializeField] private BallController ball;
    [SerializeField] private PowerUpManager powerUpManager;

    public void AddRightScore(int increment)
    {
        rightScore += increment;
        ball.ResetBall();
        powerUpManager.RemoveAllPowerUp();
        powerUpManager.ResetTimer();

        if (rightScore >= maxScore)
        {
            GameOver();
        }
    }

    public void AddLeftScore(int increment)
    {
        leftScore += increment;
        ball.ResetBall();
        powerUpManager.RemoveAllPowerUp();
        powerUpManager.ResetTimer();

        if (leftScore >= maxScore)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
