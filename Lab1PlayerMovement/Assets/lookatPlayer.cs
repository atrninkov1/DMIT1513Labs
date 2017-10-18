using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatPlayer : MonoBehaviour {


    [SerializeField]
    private Transform playerPosition;

    // Update is called once per frame
    void Update () {
        transform.LookAt(playerPosition);
	}
}
