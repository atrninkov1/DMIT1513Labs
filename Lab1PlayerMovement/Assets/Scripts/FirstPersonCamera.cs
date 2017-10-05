using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour {

    public Transform rotation;
	
	// Update is called once per frame
	void Update () {
        transform.rotation = rotation.rotation;
	}
}
