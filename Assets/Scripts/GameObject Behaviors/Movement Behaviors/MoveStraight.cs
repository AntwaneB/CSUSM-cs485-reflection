using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : Movement
{
    public float speed = 20;
    public float lifetime = 10;

    private Rigidbody rb;
    private float creationTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        creationTime = Time.time;
    }

    private void Update()
    {
        if (!movementPaused && Time.time >= creationTime + lifetime)
            Object.Destroy(this.gameObject);
    }
}
