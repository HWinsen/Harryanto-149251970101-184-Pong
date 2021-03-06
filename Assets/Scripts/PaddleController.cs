using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [SerializeField] private GameObject topContainer;
    [SerializeField] private GameObject bottomContainer;
    private Vector3 defaultScale;
    private Vector3 defaultPosition;
    private int defaultSpeed;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        defaultScale = new Vector3(0.3f, 2f, 1f);
        defaultPosition = new Vector3(transform.position.x, 0, transform.position.z);
        defaultSpeed = speed;
    }

    private void Update()
    {
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        // get input
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("Test: " + movement);
        rig.velocity = movement;
    }

    public void ResetPaddle()
    {
        transform.position = defaultPosition;
    }

    public void SpawnUnderTopContainer()
    {
        transform.position = new Vector3 (transform.position.x, topContainer.transform.position.y - topContainer.transform.localScale.y - 1, transform.position.z);
    }

    public void SpawnAboveBottomContainer()
    {
        transform.position = new Vector3(transform.position.x, bottomContainer.transform.position.y + bottomContainer.transform.localScale.y + 1, transform.position.z);
    }

    public void ActivatePULongPaddle(float magnitude)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * magnitude, transform.localScale.z);
    }

    public void DeactivatePULongPaddle()
    {
        transform.localScale = defaultScale;
    }

    public void ActivatePUFastPaddle(int magnitude)
    {
        speed *= magnitude;
    }

    public void DeactivatePUFastPaddle()
    {
        speed = defaultSpeed;
    }
}
