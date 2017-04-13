using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPositions : Movement
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 1.0F;
    public float breakDuration = 0;

    // Used to switch direction and take a break time
    private bool movementBreak;
    private float startTime;
    private float movementLength;

    // Used to pause the movement of the platform
    private float timePaused;
    private float oldStartTime;

    private void Start()
    {
        movementBreak = false;
        startTime = Time.time;
        movementLength = Vector3.Distance(startPosition, endPosition);
    }

    private void Update()
    {
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

        if (!movementPaused && !movementBreak)
            StartCoroutine(move());
    }

    private IEnumerator move()
    {
        if (!movementPaused)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / movementLength;
            transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);

            if (fracJourney >= 1)
            {
                movementBreak = true;
                yield return new WaitForSeconds(breakDuration);
                movementBreak = false;

                Vector3 tmp = startPosition;
                startPosition = endPosition;
                endPosition = tmp;

                startTime = Time.time;
                movementLength = Vector3.Distance(startPosition, endPosition);
            }
        }
    }
}
