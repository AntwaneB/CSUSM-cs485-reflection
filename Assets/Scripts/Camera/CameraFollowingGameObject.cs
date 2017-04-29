using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;

public class CameraFollowingGameObject : MonoBehaviour, EventListener
{
    public GameObject objectToFollow;

    public float zoomScale;
    public float cameraMinHeight;
    public float cameraMaxHeight;
    public float panScale;

    private Vector3 panOffset;

    private Vector3 panCenter;


    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - objectToFollow.transform.position;
        transform.position = objectToFollow.transform.position + offset;

        //Subscribe to MouseWheelEvent
        EventManager.get().Subscribe(this, new HashSet<Type>
        {
            typeof(WheelActionEvent)
        });

    }

    private void LateUpdate()
    {
        Pan();
        transform.position = objectToFollow.transform.position + offset + panOffset;
    }

    public void OnNotify(EventSystem.Event e)
    {
        if (e is WheelActionEvent)
        {
            WheelActionEvent wheelInput = e as WheelActionEvent;

            Zoom(wheelInput.Axis);
        }
    }

    //Code to zoom in or out with the mouse wheel
    private void Zoom(float axis)
    {
        offset += transform.forward * axis * zoomScale;
        if (offset.y < cameraMinHeight)
        {
            offset -= transform.forward * axis * zoomScale;
        }
        else if (offset.y > cameraMaxHeight)
        {
            offset -= transform.forward * axis * zoomScale;
        }
    }

    //Code to pan when holding down mouse
    private void Pan()
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
        //Old Code for border pan
        /*
        float panX;
        float panY;
        float panBorder = 8;
        if(Input.mousePosition.x > Screen.width - Screen.width/panBorder)
        {
            panX = (Input.mousePosition.x - (Screen.width - Screen.width/panBorder)) *panScale;
        }
        else if (Input.mousePosition.x < Screen.width / panBorder)
        {
            panX = -(Screen.width/6 - Input.mousePosition.x) * panScale;
        }
        else
        {
            panX = 0;
        }
        if(Input.mousePosition.y > Screen.height - Screen.height / panBorder)
        {
            panY = (Input.mousePosition.y - (Screen.height - Screen.height/panBorder)) * panScale;
        }
        else if(Input.mousePosition.y < Screen.height / panBorder)
        {
            panY = -(Screen.height / panBorder - Input.mousePosition.y) * panScale;
        }
        else
        {
            panY = 0;
        }
        panVector = new Vector3(panX, 0, panY);
        */
    }
}
