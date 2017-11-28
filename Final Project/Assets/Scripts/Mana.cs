using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour {

    [SerializeField]
    CardManager manaInfo;

    enum manaType
    {
        red,
        blue,
        yellow
    }
    [SerializeField]
    manaType type;
	// Update is called once per frame
	void Update () {
        switch (type)
        {
            case manaType.red:
                GetComponent<Text>().text = manaInfo.CurrentRedMana + "/ " + manaInfo.MaxRedMana;
                break;
            case manaType.blue:
                GetComponent<Text>().text = manaInfo.CurrentBlueMana + "/ " + manaInfo.MaxBlueMana;
                break;
            case manaType.yellow:
                GetComponent<Text>().text = manaInfo.CurrentYellowMana + "/ " + manaInfo.MaxYellowMana;
                break;
            default:
                break;
        }
    }
}
