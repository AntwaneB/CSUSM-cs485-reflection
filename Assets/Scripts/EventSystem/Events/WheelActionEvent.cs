using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelActionEvent : EventSystem.Event
{
    public float Axis { get; set; }

    public WheelActionEvent(float axis)
    {
        Axis = axis;
    }
}
