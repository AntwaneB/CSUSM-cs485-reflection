using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectProjectiles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PROJECTILE"))
        {
            Rigidbody otherRb = other.GetComponent<Rigidbody>();
            
            // Get projectile reflection vector
            Vector3 reflection = other.transform.forward - 2 * Vector3.Dot(other.transform.forward, transform.forward) * transform.forward;

            // Reflect projectile
            float lateralSpeed = new Vector2(otherRb.velocity.x, otherRb.velocity.z).magnitude;
            otherRb.velocity = new Vector3(reflection.x * lateralSpeed, 0, reflection.z * lateralSpeed);

            other.transform.forward = reflection;
        }
    }
}
