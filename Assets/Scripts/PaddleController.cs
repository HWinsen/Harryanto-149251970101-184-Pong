using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    private Vector3 defaultScale;
    private Vector3 defaultPosition;
    private int defaultSpeed;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        defaultScale = new Vector3(0.3f, 2f, 1f);
        defaultPosition = new Vector3(transform.position.x, 0, transform.position.z);
        defaultSpeed = speed;
    }

    // Update is called once per frame
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
        //Debug.Log("Test: " + movement);
        rig.velocity = movement;
    }

    public void ResetPaddle()
    {
        transform.position = defaultPosition;
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
