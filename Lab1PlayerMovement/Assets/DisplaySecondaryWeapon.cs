using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySecondaryWeapon : MonoBehaviour {

    public PlayerController secondaryWeapon;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (secondaryWeapon.selectedWeapon)
        {
            case PlayerController.weaponSelected.weapon1:
                GetComponent<Text>().text = "Weapon1: ";
                break;
            case PlayerController.weaponSelected.weapon2:
                GetComponent<Text>().text = "Weapon2: ";
                break;
            default:
                break;
        }
    }
}
