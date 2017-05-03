using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;

public class CameraZooming : MonoBehaviour, EventListener
{
    public float zoomScale = 15;
    public float cameraMinHeight = 10;
    public float cameraMaxHeight = 30;

    private Vector3 offset;

    private void Start()
    {
        EventManager.get().Subscribe(this, new HashSet<Type>
        {
            typeof(WheelActionEvent)
        });
    }

    public void OnNotify(EventSystem.Event e)
    {
        if (e is WheelActionEvent)
        {
            WheelActionEvent wheelInput = e as WheelActionEvent;

            zoom(wheelInput.Axis);
        }
    }

    private void zoom(float axis)
    {
        transform.Translate(Vector3.forward * axis * zoomScale);

        if (transform.position.y < cameraMinHeight || transform.position.y > cameraMaxHeight)
        {
            transform.Translate(Vector3.forward * -axis * zoomScale);
        }
    }
}
