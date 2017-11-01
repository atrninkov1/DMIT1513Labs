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
                print(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "PlayerControlled")
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

        for (int i = 0; i < agents.Count; i++)
        {
            if (agents[i].velocity.magnitude > 0)
            {
                agents[i].gameObject.GetComponent<Animator>().SetBool("Moving", true);
            }
            else
            {
                agents[i].gameObject.GetComponent<Animator>().SetBool("Moving", false);
            }
        }
        if (Input.mousePosition.y >= Screen.height * 0.95)
        {
            transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.y <= Screen.height * 0.05)
        {
            transform.Translate(Vector3.forward * -Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.x >= Screen.width * 0.95)
        {
            transform.Translate(Vector3.right * Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.x <= Screen.width * 0.05)
        {
            transform.Translate(Vector3.right * -Time.deltaTime, Space.World);
        }
    }
}
