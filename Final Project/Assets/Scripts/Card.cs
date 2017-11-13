using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    bool positionSet = false;
    bool positionSetOnShrink = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        transform.localScale = new Vector3(2, 2, 1);
        if (!positionSet)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f,-1);
            positionSet = true;
            positionSetOnShrink = false;
        }
    }

    private void OnMouseExit()
    {
        if (!positionSetOnShrink)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, -1);
            positionSet = false;
            positionSetOnShrink = true;
        }
        transform.localScale = new Vector3(1, 1, 1);
    }
}
