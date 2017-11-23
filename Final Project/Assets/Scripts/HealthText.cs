using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.parent.GetComponent<Card>().Health.ToString() != null)
        {
            GetComponent<TextMesh>().text = transform.parent.GetComponent<Card>().Health.ToString();
        }
	}
}
