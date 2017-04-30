using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;

public class ButtonController : MonoBehaviour { 

    public Material depressedMat;
    public Material extendedMat;

    private Renderer ren;

    private bool depressed;
    private float depressAmount;
    private Vector3 extendedPos;
    private Vector3 depressedPos;

    private void Start()
    {
        depressed = false;
        depressAmount = 0.5f; //Default
        extendedPos = transform.localPosition;
        depressedPos = extendedPos;
        depressedPos.y = depressedPos.y - depressAmount;

        ren = GetComponent<Renderer>();
        ren.material = extendedMat;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PROJECTILE"))
        {
            other.gameObject.SetActive(false);
            if (!depressed)
            {
                Depress();
            }
            else
            {
                Unpress();
            }
        }
    }

    private void Depress()
    {
        if (depressed == false)
        {
            depressed = true;
            transform.localPosition = depressedPos;
            ren.material = depressedMat;
            EventManager.get().Notify(new ButtonPressedEvent(depressed, this.gameObject));
        }
    }

    private void Unpress()
    {
        if (depressed == true)
        {
            depressed = false;
            transform.localPosition = extendedPos;
            ren.material = extendedMat;
            EventManager.get().Notify(new ButtonPressedEvent(depressed, this.gameObject));
        }
    }
}
