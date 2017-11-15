using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldScript : MonoBehaviour {

    [SerializeField]
    enum fieldType
    {
        red,
        blue,
        yellow
    }

    [SerializeField]
    fieldType cardCostType = fieldType.red;


}
