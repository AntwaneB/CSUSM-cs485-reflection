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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = rb.gameObject.transform.position.y;
        transform.LookAt(mousePosition);
    }
}
