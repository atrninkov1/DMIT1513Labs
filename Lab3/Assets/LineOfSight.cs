using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour {

    internal GameObject Target;
    internal GameObject HealthPack;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerControlled")
        {
            Target = other.gameObject;
        }
        if(other.gameObject.tag == "HealthPack")
        {
            HealthPack = other.gameObject;
        }
    }
}
