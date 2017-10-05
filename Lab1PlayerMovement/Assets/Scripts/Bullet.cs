using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float destroyTime;
    float destroyDelay = 10;

    // Use this for initialization
    void Start()
    {
        destroyTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > destroyTime + destroyDelay)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "StationaryTarget")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().LoseHP();
        }
        Destroy(gameObject);
    }
}
