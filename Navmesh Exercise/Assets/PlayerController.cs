using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public List<NavMeshAgent> agents;
    public GameObject bullet;

    RaycastHit hit;
    float attackTimeStamp;

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
                if (hit.collider.gameObject.tag == "Enemy" && agents.Count > 0)
                {
                    for (int i = 0; i < agents.Count; i++)
                    {
                        agents[i].destination = hit.point;
                        agents[i].stoppingDistance = 3;
                        if (Vector3.Distance(hit.collider.transform.position, agents[i].transform.position) <= 4)
                        {
                            GameObject projectile = Instantiate(bullet);
                            bullet.transform.position = agents[i].transform.position;
                            bullet.transform.LookAt(hit.collider.gameObject.transform.position);
                            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 100f);
                        }
                    }
                }
            }
        }
        for (int i = 0; i < agents.Count; i++)
        {
            if (Vector3.Distance(hit.collider.transform.position, agents[i].transform.position) <= 3 && hit.collider.gameObject.tag == "Enemy" && Time.time > attackTimeStamp + 1)
            {
                GameObject projectile = Instantiate(bullet);
                bullet.transform.position = agents[i].transform.position;
                bullet.transform.LookAt(hit.collider.gameObject.transform.position);
                projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 100f);
                attackTimeStamp = Time.time;
            }
        }
    }
}
