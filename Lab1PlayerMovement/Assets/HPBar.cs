using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {

    [SerializeField]
    private Turret turret;
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(0.1f * turret.hpPercent, 0.1f,2);
	}
}
