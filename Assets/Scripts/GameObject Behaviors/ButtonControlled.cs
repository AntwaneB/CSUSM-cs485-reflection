using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;

public abstract class ButtonControlled : MonoBehaviour, EventListener
{
    public GameObject linkedButton;

    private void Start()
    {
        EventManager.get().Subscribe(this, new HashSet<Type>
        {
            typeof(ButtonPressedEvent)
        });
    }

    public void OnNotify(EventSystem.Event e)
    {
        if (e is ButtonPressedEvent)
        {
            ButtonPressedEvent buttonPressed = e as ButtonPressedEvent;

            if (buttonPressed.GameObject == linkedButton)
            {
                if (buttonPressed.Pressed)
                    activate();
                else
                    deactivate();
            }
        }
    }

    protected abstract void activate();

    protected abstract void deactivate();
}
