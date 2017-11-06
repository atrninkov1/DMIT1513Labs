using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuyScript : MonoBehaviour
{

    public GameObject target;
    public float range = 200;
    public GameObject selectedIndicator;
    [SerializeField]
    GameObject arrow;
    GameObject weapon;
    void Start()
    {
        weapon = transform.GetChild(4).gameObject;
    }

    void Fire()
    {
        if (range > 100)
        {
            GameObject projectile = Instantiate(arrow);
            projectile.transform.position = weapon.transform.position + (transform.forward * 4);
            projectile.transform.LookAt(target.transform);
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
        }
    }
}
