using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryTurret : MonoBehaviour {

    public GameObject bullet;
    private float delayStampWeapon1;
    Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.GetChild(0).GetComponent<TurretRadar>().player != null)
        {
            target = transform.GetChild(0).GetComponent<TurretRadar>().player.transform;
            var heading = target.position - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.

            if (Time.time > delayStampWeapon1 + 1)
            {
                GameObject projectile = Instantiate(bullet);
                projectile.transform.position = transform.position + (10 * direction);
                projectile.transform.rotation = transform.rotation;
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce(direction * 70);
                delayStampWeapon1 = Time.time;
            }
        }
    }
}
