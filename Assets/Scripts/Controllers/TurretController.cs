using System.Collections.Generic;
using EventSystem;
using UnityEngine;
using System;

public class TurretController : MonoBehaviour, EventListener
{
    private void Start()
    {
        EventManager.get().Subscribe(this, new HashSet<Type>
            {
                typeof(UnitDiedEvent)
            });
    }

    public void OnNotify(EventSystem.Event e)
    {
        if (e is UnitDiedEvent)
        {
            UnitDiedEvent unitDiedEvent = e as UnitDiedEvent;

            if (unitDiedEvent.GameObject == this.gameObject)
            {
                die();
            }
        }
    }

    private void die()
    {
        gameObject.SetActive(false);
        //GameObject.Destroy(this.gameObject);
    }
}