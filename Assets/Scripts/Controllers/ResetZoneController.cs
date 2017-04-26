using EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.get().Notify(new RespawnHitEvent());
        }
    }
}
