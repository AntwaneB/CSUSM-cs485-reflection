using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;

public class InputMovement : MonoBehaviour, EventListener
{
    public float speed = 20;

    private Rigidbody rb;

    private void Start()
    {
        EventManager.get().Subscribe(this, new HashSet<Type>
        {
            typeof(MovementInputEvent)
        });

        rb = GetComponent<Rigidbody>() as Rigidbody;
    }

    public void OnNotify(EventSystem.Event e)
    {
        if (e is MovementInputEvent)
        {
            MovementInputEvent movementInput = e as MovementInputEvent;

            Move(movementInput.Horizontal, movementInput.Vertical);
        }
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }
}
