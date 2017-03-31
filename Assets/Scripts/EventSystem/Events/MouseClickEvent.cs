using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickEvent : EventSystem.Event
{
    public KeyCode Button { get; set; }

    public MouseClickEvent(KeyCode button)
    {
        Button = button;
    }
}
