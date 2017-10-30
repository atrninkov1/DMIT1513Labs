using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public List<NavMeshAgent> agents;
    RaycastHit hit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(transform.position, ray.direction, out hit, 1000))
            {
                if (hit.collider.gameObject.tag == "PlayerMinion")
                {
                    agents.Add(hit.collider.gameObject.GetComponent<NavMeshAgent>());
                }
                if (hit.collider.gameObject.tag == "Floor" && agents.Count > 0)
                {
                    for (int i = 0; i < agents.Count; i++)
                    {
                        agents[i].destination = hit.point;
                    }
                }
            }
        }
    }
}
