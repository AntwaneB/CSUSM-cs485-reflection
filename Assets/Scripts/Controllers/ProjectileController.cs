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

    private void OnDestroy()
    {
        Instantiate(Resources.Load("ProjectileFlash"), transform.position, transform.rotation, dynamicsHolder.transform);
    }
}
