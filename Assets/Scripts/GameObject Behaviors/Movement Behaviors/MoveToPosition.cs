using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : Movement
{
    public Vector3 endPosition;
    public float speed = 1.0F;

    // Used to switch direction and take a break time
    private float startTime;
    private float movementLength;
    private Vector3 startPosition;
    private bool done;

    // Used to pause the movement of the platform
    private float timePaused;
    private float oldStartTime;

    private void Start()
    {
        done = false;

        startTime = Time.time;
        startPosition = transform.position;

        movementLength = Vector3.Distance(startPosition, endPosition);
    }

    private void Update()
    {
        if (done)
            return;

        // Store info to unpause the movement of the platform
        if (movementPaused && startTime >= 0)
        {
            timePaused = Time.time;
            oldStartTime = startTime;
            startTime = -1;
        } // Unpause the movement of the platform
        else if (!movementPaused && startTime < 0)
        {
            startTime = Time.time - (timePaused - oldStartTime);
        }

        if (!movementPaused)
            move();
    }

    private void move()
    {
        if (!movementPaused && !done)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / movementLength;
            transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
        }
    }
}
