using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class ButtonController : MonoBehaviour
{

    public Material depressedMat;
    public Material extendedMat;

    private Renderer ren;

    private bool isDepressed;
    private float depressAmount;
    private Vector3 extendedPos;
    private Vector3 depressedPos;

    // Use this for initialization
    void Start()
    {
        isDepressed = false;
        depressAmount = 0.5f; //Default
        extendedPos = transform.localPosition;
        depressedPos = extendedPos;
        depressedPos.y = depressedPos.y - depressAmount;

        ren = GetComponent<Renderer>();
        ren.material = extendedMat;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PROJECTILE"))
        {
            other.gameObject.SetActive(false);
            Depress();
        }
    }

    private void Depress()
    {
        if (isDepressed == false)
        {
            isDepressed = true;
            transform.localPosition = depressedPos;
            ren.material = depressedMat;
            EventManager.get().Notify(new ButtonPressedEvent(isDepressed, this.name));
        }
    }
    private void Unpress()
    {
        if (isDepressed == true)
        {
            isDepressed = false;
            transform.localPosition = extendedPos;
            ren.material = extendedMat;
            EventManager.get().Notify(new ButtonPressedEvent(isDepressed, this.name));
        }
    }
}