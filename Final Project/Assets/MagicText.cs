using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        if (transform.parent.GetComponent<Card>().MagicPower.ToString() != null)
        {
            GetComponent<TextMesh>().text = transform.parent.GetComponent<Card>().MagicPower.ToString();
        }
    }
}
