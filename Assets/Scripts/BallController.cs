using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Vector2 speed;
    private Rigidbody2D rig;

    private void Awake()
    {
        speed = new Vector2(6 * (Random.Range(0, 2) * 2 - 1), Random.Range(0, 2) * 2 - 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
