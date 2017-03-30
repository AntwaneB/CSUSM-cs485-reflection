using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPositions : MonoBehaviour
{

    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 1.0F;
    public float pauseDuration = 0;

    private bool movementPaused;
    private float startTime;
    private float movementLength;

    private void Start()
    {
        movementPaused = false;
        startTime = Time.time;
        movementLength = Vector3.Distance(startPosition, endPosition);
    }

    private void Update()
    {
        if (!movementPaused)
            StartCoroutine(move());
    }

    private IEnumerator move()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / movementLength;
        transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);

        if (fracJourney >= 1)
        {
            movementPaused = true;
            yield return new WaitForSeconds(pauseDuration);
            movementPaused = false;

            Vector3 tmp = startPosition;
            startPosition = endPosition;
            endPosition = tmp;

            startTime = Time.time;
            movementLength = Vector3.Distance(startPosition, endPosition);
        }
    }
}
