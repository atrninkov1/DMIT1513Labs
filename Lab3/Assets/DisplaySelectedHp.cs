using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySelectedHp : MonoBehaviour
{

    public PlayerController playerController;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.selected != null)
        {
            GetComponent<RectTransform>().localScale = new Vector3(playerController.selected.GetComponent<EnemyHPScript>().currentHP / playerController.selected.GetComponent<EnemyHPScript>().maxHP,
            GetComponent<RectTransform>().localScale.y, GetComponent<RectTransform>().localScale.z);
        }
    }
}
