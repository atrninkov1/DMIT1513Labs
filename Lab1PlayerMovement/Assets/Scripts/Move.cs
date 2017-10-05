using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    float movespeed = 30.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PatrolEnd")
        {
            movespeed *= -1;
        }
    }
}
