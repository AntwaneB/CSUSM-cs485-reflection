using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressedEvent : EventSystem.Event
{
    public bool Pressed { get; set; }
    public GameObject GameObject { get; set; }

    public ButtonPressedEvent(bool pressed, GameObject gameObject)
    {
        Pressed = pressed;
        GameObject = gameObject;
    }

}
