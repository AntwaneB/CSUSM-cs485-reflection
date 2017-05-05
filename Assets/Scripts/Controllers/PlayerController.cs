using System.Collections.Generic;
using EventSystem;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour, EventListener
{
    public GameObject character;
    public GameObject shield;

    private void Start()
    {
        EventManager.get().Subscribe(this, new HashSet<Type>
        {
            typeof(MouseClickEvent),
            typeof(UnitDiedEvent)
        });
    }

    public void OnNotify(EventSystem.Event e)
    {
        if (e is MouseClickEvent)
        {
            MouseClickEvent mouseClickEvent = e as MouseClickEvent;

            switch (mouseClickEvent.Button)
            {
                case KeyCode.Mouse0:
                    break;
                case KeyCode.Mouse1:
                    break;
            }
        }
        else if (e is UnitDiedEvent)
        {
            UnitDiedEvent unitDiedEvent = e as UnitDiedEvent;

            if (unitDiedEvent.GameObject == this.gameObject
                || unitDiedEvent.GameObject == character)
            {
                die();
            }
        }
    }

    private void die()
    {
        //GameObject.Destroy(this.gameObject);
    }
}
