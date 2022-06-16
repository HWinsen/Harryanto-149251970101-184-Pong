using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerHandler : MonoBehaviour
{
    // Mencegah terjadinya bug ketika Bola keluar kamera

    [SerializeField] private Collider2D ball;
    [SerializeField] private PowerUpManager powerUpManager;
    [SerializeField] private PaddleController leftPaddle;
    [SerializeField] private PaddleController rightPaddle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            Debug.Log("Out of Bound");
            ball.GetComponent<BallController>().ResetBall();
            ball.GetComponent<BallController>().RandomBall();
            leftPaddle.ResetPaddle();
            rightPaddle.ResetPaddle();
            powerUpManager.RemoveAllPowerUp();
            powerUpManager.ResetPUState();
            powerUpManager.ResetTimer();
        }
    }
}
