using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private GameObject dynamicsHolder;

    private void Start()
    {
        dynamicsHolder = GameObject.FindWithTag("DYNAMICS_HOLDER");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untagged"))
        {
            dieByCollision();
        }
    }

    private void dieByCollision()
    {
        Instantiate(Resources.Load("ProjectileFlash"), transform.position, transform.rotation, dynamicsHolder.transform);

        GameObject.Destroy(this.gameObject);
    }
}
