using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentWaypoint = 0;
    NavMeshAgent myAgent;
    // Use this for initialization
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.destination = waypoints[currentWaypoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) <= 3.0f)
        {
            currentWaypoint++;
            if (currentWaypoint > waypoints.Length - 1)
            {
                currentWaypoint = 0;
            }

            myAgent.destination = waypoints[currentWaypoint].transform.position;
            myAgent.stoppingDistance = 3.0f;
        }
        if (getCom)
        {

        }
    }
}
