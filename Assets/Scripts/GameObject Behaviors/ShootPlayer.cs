using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour {

    public float fireCooldown;

    private GameObject player;

    private float nextFire;

    private GameObject dynamicsHolder;

    void Start () {
        player = GameObject.FindWithTag("Player");
        dynamicsHolder = GameObject.FindWithTag("DYNAMICS_HOLDER");
    }
	
	void Update () {
        this.transform.LookAt(player.transform);
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireCooldown;
            fire();
        }
    }

    private void fire()
    {
        Vector3 projectilePosition = transform.position;
        Quaternion projectileRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        Instantiate(Resources.Load("LaserBolt"), projectilePosition, projectileRotation, dynamicsHolder.transform);
    }
}
