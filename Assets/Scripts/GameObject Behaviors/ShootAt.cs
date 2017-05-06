using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAt : MonoBehaviour
{
    public GameObject target;
    public float fireCooldown = 1;

    private float nextFire;

    private GameObject dynamicsHolder;

    private void Start()
    {
        dynamicsHolder = GameObject.FindWithTag("DYNAMICS_HOLDER");

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
        Vector3 projectilePosition = transform.position + transform.forward;
        Quaternion projectileRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        Instantiate(Resources.Load("LaserBolt"), projectilePosition, projectileRotation, dynamicsHolder.transform);
    }
}
