using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerHandler : MonoBehaviour
{
    // Mencegah terjadinya bug ketika Bola keluar kamera

    [SerializeField] private Collider2D ball;
    [SerializeField] private PowerUpManager powerUpManager;
    [SerializeField] private Collider2D leftPaddle;
    [SerializeField] private Collider2D rightPaddle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            Debug.Log("Ball Out of Bound");
            ball.GetComponent<BallController>().ResetBall();
            ball.GetComponent<BallController>().RandomBall();
            leftPaddle.GetComponent<PaddleController>().ResetPaddle();
            rightPaddle.GetComponent<PaddleController>().ResetPaddle();
            powerUpManager.RemoveAllPowerUp();
            powerUpManager.ResetPUState();
            powerUpManager.ResetTimer();
        }

        if (collision == leftPaddle)
        {
            Debug.Log("Left Paddle Out of Bound");
            if (gameObject.name == "TopContainer")
            {
                leftPaddle.GetComponent<PaddleController>().SpawnAboveBottomContainer();
            }
            else if (gameObject.name == "BottomContainer")
            {
                leftPaddle.GetComponent<PaddleController>().SpawnUnderTopContainer();
            }
        }
        else if (collision == rightPaddle)
        {
            Debug.Log("Right Paddle Out of Bound");
            if (gameObject.name == "TopContainer")
            {
                rightPaddle.GetComponent<PaddleController>().SpawnAboveBottomContainer();
            }
            else if (gameObject.name == "BottomContainer")
            {
                rightPaddle.GetComponent<PaddleController>().SpawnUnderTopContainer();
            }
        }
    }
}
