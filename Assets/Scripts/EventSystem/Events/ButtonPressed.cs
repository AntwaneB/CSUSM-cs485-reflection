using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressedEvent : EventSystem.Event
{
    public bool Pressed { get; set; }
    public string Name { get; set; }

    public ButtonPressedEvent(bool pressed, string name)
    {
        Pressed = pressed;
        Name = name;
    }

}
