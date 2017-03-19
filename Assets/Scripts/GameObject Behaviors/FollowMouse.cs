using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>() as Rigidbody;
    }

    private void FixedUpdate()
    {
        Turn();
    }

    private void Turn()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, 100f))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 objectToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            objectToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(objectToMouse);

            // Set the player's rotation to this new rotation.
            rb.MoveRotation(newRotation);
        }
    }
}
