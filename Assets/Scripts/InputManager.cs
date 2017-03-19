using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class InputManager : MonoBehaviour
{
    private void FixedUpdate()
    {
        playerMovement();
    }

    private void playerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        EventManager.get().Notify(new MovementInputEvent(moveHorizontal, moveVertical));
    }
}
