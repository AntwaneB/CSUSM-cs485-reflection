using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputEvent : EventSystem.Event
{

    public float Horizontal { get; set; }
    public float Vertical { get; set; }

    public MovementInputEvent(float horizontal, float vertical)
    {
        Horizontal = horizontal;
        Vertical = vertical;
    }

}
