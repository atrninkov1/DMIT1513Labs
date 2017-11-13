using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParticles : MonoBehaviour {

    public Animator animator;
	
	// Update is called once per frame
	void Update () {
        if (animator.GetBool("Attacking"))
        {
            GetComponent<ParticleSystem>().Play();
        }
	}
}
