using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDiedEvent : EventSystem.Event
{
    public GameObject GameObject { get; set; }

    public UnitDiedEvent(GameObject gameObject)
    {
        GameObject = gameObject;
    }
}
