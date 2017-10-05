using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomIn : MonoBehaviour
{
    float scrollInput;
    float zoomSpeed = 300;
    int zoom = 20;
    public Transform playerPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if ((zoom > 0 || scrollInput<0) && (zoom < 200 || scrollInput>0))
        {
            transform.Translate(Vector3.forward * scrollInput * Time.deltaTime * zoomSpeed);
            if (scrollInput>0)
            {
                zoom--;
            }
            else if (scrollInput<0)
            {
                zoom++;
            }
        }
    }
}
