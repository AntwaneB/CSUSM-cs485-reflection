using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;

public class CameraFollowingGameObject : MonoBehaviour
{
    public GameObject objectToFollow;

    public float panScale;
    private Vector3 panOffset;
    private Vector3 panCenter;

    private Vector3 offset;
    private Vector3 previousPosition;

    private void Start()
    {
        offset = transform.position - objectToFollow.transform.position;
        transform.position = objectToFollow.transform.position + offset;
        previousPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (objectToFollow == null)
            return;

        pan();
        follow();
    }

    private void follow()
    {
        if (transform.position != previousPosition)
        {
            offset = transform.position - objectToFollow.transform.position;
        }

        transform.position = objectToFollow.transform.position + offset + panOffset;
        previousPosition = transform.position;
    }

    private void pan()
    {
        if(Input.GetMouseButtonDown(2))
        {
            panCenter = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
            panOffset = (Input.mousePosition - panCenter) * panScale;
            panOffset = new Vector3(panOffset.x, 0, panOffset.y);
        }
        if ( Input.GetMouseButtonUp(2))
        {
            panOffset = new Vector3(0, 0, 0);
        }
    }
}
