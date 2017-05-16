using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;

public abstract class UnitsDeathControlled : MonoBehaviour, EventListener
{
    public GameObject[] Units;
    private int unitCount;
    private bool activated;

    protected void initListener()
    {
        activated = false;

        unitCount = Units.Length;
        Debug.Log(unitCount);
        EventManager.get().Subscribe(this, new HashSet<Type>
        {
            typeof(UnitDiedEvent)
        });
    }

    private void Start()
    {
        initListener();

    }

    public void Update()
    {
        {
            if(unitCount == 0 && activated == false)
            {
                activated = true;
                activate();
            }
        }
    }

    public void OnNotify(EventSystem.Event e)
    {
        if (e is UnitDiedEvent)
        {
            UnitDiedEvent unitDiedEvent = e as UnitDiedEvent;
            foreach (GameObject unit in Units)
            {
                if (unit != null)
                {
                    if (unit == unitDiedEvent.GameObject)
                    {
                       unitCount--;
                    }
                }
            }
        }
    }
    protected abstract void activate();

    protected abstract void deactivate();
}
