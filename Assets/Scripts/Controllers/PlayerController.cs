using System.Collections.Generic;
using EventSystem;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour, EventListener
{
    public GameObject character;
    public GameObject shield;

    private GameObject dynamicsHolder;

    private void Start()
    {
        EventManager.get().Subscribe(this, new HashSet<Type>
        {
            typeof(MouseClickEvent),
            typeof(UnitDiedEvent)
        });

        dynamicsHolder = GameObject.FindWithTag("DYNAMICS_HOLDER");
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
        GameObject.Destroy(this.gameObject);
    }

    /*
    private void fire()
    {
        Vector3 projectilePosition = transform.position;
        Quaternion projectileRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        Instantiate(Resources.Load("LaserBolt"), projectilePosition, projectileRotation, dynamicsHolder.transform);
    }
    */
}
