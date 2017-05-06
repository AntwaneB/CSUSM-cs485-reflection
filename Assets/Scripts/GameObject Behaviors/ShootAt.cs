using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAt : MonoBehaviour
{
    public GameObject target;
    public float fireCooldown = 1;
    public Transform shootSpawn;

    private float nextFire;

    private GameObject dynamicsHolder;

    private void Start()
    {
        dynamicsHolder = GameObject.FindWithTag("DYNAMICS_HOLDER");

        if (shootSpawn == null)
            shootSpawn = this.transform;
    }
	
	void Update()
    {
        if (target == null)
            return;

        this.transform.LookAt(target.transform);
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireCooldown;
            fire();
        }
    }

    private void fire()
    {
        Vector3 projectilePosition = shootSpawn.position;
        Quaternion projectileRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        Instantiate(Resources.Load("LaserBolt"), projectilePosition, projectileRotation, dynamicsHolder.transform);
    }
}
