using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private BallController ball;
    [SerializeField] private PowerUpManager powerUpManager;
    [SerializeField] private PaddleController leftPaddle;
    [SerializeField] private PaddleController rightPaddle;

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Mencegah terjadinya bug ketika Bola terlock mantul tembok atas bawah

    public void ResetButton()
    {
        Debug.Log("Reset");
        ball.ResetBall();
        ball.RandomBall();
        leftPaddle.ResetPaddle();
        rightPaddle.ResetPaddle();
        powerUpManager.RemoveAllPowerUp();
        powerUpManager.ResetPUState();
        powerUpManager.ResetTimer();
    }
}
