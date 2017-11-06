using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    float createTime;

	// Use this for initialization
	void Start () {
        createTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > createTime + 5)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHPScript>().TakeDamage(100);
        }

        Destroy(gameObject);
    }
}
