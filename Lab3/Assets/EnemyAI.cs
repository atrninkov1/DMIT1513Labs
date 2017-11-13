using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentWaypoint = 0;
    NavMeshAgent myAgent;
    GameObject target;
    GameObject healthPack;
    [SerializeField]
    LineOfSight lineOfSight;
    // Use this for initialization
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.destination = waypoints[currentWaypoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (myAgent.velocity.magnitude > 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Moving", false);
        }
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) <= 3.0f && target == null && healthPack == null)
        {
            currentWaypoint++;
            if (currentWaypoint > waypoints.Length - 1)
            {
                currentWaypoint = 0;
            }
            myAgent.destination = waypoints[currentWaypoint].transform.position;
        }

        if (GetComponent<EnemyHPScript>().Target != null && target == null)
        {
            target = GetComponent<EnemyHPScript>().Target;
        }
        

        if (target == null && lineOfSight.Target != null)
        {
            target = lineOfSight.Target;
        }
        if (target != null)
        {
            myAgent.destination = target.transform.position;
            myAgent.stoppingDistance = GetComponent<PlayerGuyScript>().range;
            GetComponent<PlayerGuyScript>().target = target;
            if (GetComponent<PlayerGuyScript>().target != null &&
                Vector3.Distance(GetComponent<PlayerGuyScript>().target.transform.position, transform.position) <=
                GetComponent<PlayerGuyScript>().range)
            {
                transform.LookAt(GetComponent<PlayerGuyScript>().target.transform.position);
                gameObject.GetComponent<Animator>().SetBool("Attacking", true);
            }
            else if (GetComponent<PlayerGuyScript>().target == null ||
                Vector3.Distance(GetComponent<PlayerGuyScript>().target.transform.position, transform.position) >
                GetComponent<PlayerGuyScript>().range)
            {
                gameObject.GetComponent<Animator>().SetBool("Attacking", false);
            }
        }
        else if (gameObject.GetComponent<Animator>().GetBool("Attacking") && target == null)
        {
            GetComponent<EnemyHPScript>().RemoveTarget();
            gameObject.GetComponent<Animator>().SetBool("Attacking", false);
            myAgent.stoppingDistance = 0;
            myAgent.destination = waypoints[currentWaypoint].transform.position;
        }
        if (target == null && healthPack == null && lineOfSight.HealthPack != null)
        {
            healthPack = lineOfSight.HealthPack;
            myAgent.destination = healthPack.transform.position;
        }

    }
}
