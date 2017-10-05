using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject followPoint3dPerson;
    public GameObject followPoint1stPerson;
    public GameObject followPointTopDown;
    public GameObject player;
    public PlayerController script;

    // Update is called once per frame
    void Update()
    {
        if (script.thirdPerson == PlayerController.cameraMode.thirdPerson)
        {
            transform.position = Vector3.Slerp(transform.position, followPoint3dPerson.transform.position, 10.0f);
            transform.LookAt(player.transform);
        }
        else if (script.thirdPerson == PlayerController.cameraMode.firstPerson)
        {
            transform.position = followPoint1stPerson.transform.position;
            transform.rotation = followPoint1stPerson.transform.rotation;
        }
        else if (script.thirdPerson == PlayerController.cameraMode.topDown)
        {
            transform.position = followPointTopDown.transform.position;
            transform.rotation = followPointTopDown.transform.rotation;
        }
        
    }
}
