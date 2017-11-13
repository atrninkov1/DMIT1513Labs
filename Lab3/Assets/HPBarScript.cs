using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarScript : MonoBehaviour
{

    public EnemyHPScript hpScript;



    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().localScale = new Vector3((float)hpScript.currentHP / (float)hpScript.maxHP, GetComponent<RectTransform>().localScale.y, GetComponent<RectTransform>().localScale.z);
    }
}
