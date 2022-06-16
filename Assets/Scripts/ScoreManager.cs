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
    [SerializeField] private PaddleController leftPaddle;
    [SerializeField] private PaddleController rightPaddle;

    public void AddRightScore(int increment)
    {
        rightScore += increment;
        ball.ResetBall();
        ball.RandomBall();
        leftPaddle.ResetPaddle();
        rightPaddle.ResetPaddle();
        powerUpManager.RemoveAllPowerUp();
        powerUpManager.ResetPUState();
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
        ball.RandomBall();
        leftPaddle.ResetPaddle();
        rightPaddle.ResetPaddle();
        powerUpManager.RemoveAllPowerUp();
        powerUpManager.ResetPUState();
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
