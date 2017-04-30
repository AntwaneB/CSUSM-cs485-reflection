using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;

public class BridgeController : MonoBehaviour, EventListener {

    public GameObject linkedButton;
    private float length;
	// Use this for initialization
	void Start () {
        length = transform.localScale.x;

        EventManager.get().Subscribe(this, new HashSet<Type>
        {
            typeof(ButtonPressedEvent)
        });
    }
	
	// Update is called once per frame
	void Update () {
	}

    private IEnumerator SlideOpen()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.position += -(transform.right * length / 10);
            yield return null;
        }
    }


    public void OnNotify(EventSystem.Event e)
    {
        if (e is ButtonPressedEvent)
        {
            ButtonPressedEvent buttonPressed = e as ButtonPressedEvent;

            if (buttonPressed.GameObject == linkedButton)
            {
                if (buttonPressed.Pressed)
                    StartCoroutine(SlideOpen());
            }
        }
    }
}
