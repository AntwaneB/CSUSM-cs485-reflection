using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class DamagedOnHit : MonoBehaviour
{
    public int startingHealth = 100;
    public int damageOnHit = 34;

    private int currentHealth;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    // For the player it requires to have another collider set as trigger alongside the default collider for physics
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PROJECTILE"))
        {
            currentHealth -= damageOnHit;

            if (currentHealth <= 0)
            {
                EventManager.get().Notify(new UnitDiedEvent(this.gameObject));
            }
        }
    }
}
