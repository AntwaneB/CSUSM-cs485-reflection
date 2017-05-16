using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;

public class EMPController : MonoBehaviour, EventListener {

    public GameObject[] connectedTurrets; 

	void Start () {
        EventManager.get().Subscribe(this, new HashSet<Type>
        {
            typeof(UnitDiedEvent)
        });
    }
	
	void Update ()
    {
    }

    public void OnNotify(EventSystem.Event e)
    {
        if (e is UnitDiedEvent)
        {
            UnitDiedEvent unitDiedEvent = e as UnitDiedEvent;

            if (unitDiedEvent.GameObject == this.gameObject)
            {
                UnitDiedEvent unitDied = e as UnitDiedEvent;
                foreach (GameObject turret in connectedTurrets)
                {
                    if (turret != null)
                    {
                        EventManager.get().Notify(new UnitDiedEvent(turret));
                    }
                }
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
