using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public List<NavMeshAgent> agents;
    public float ScrollSpeed = 3.0f;
    [SerializeField]
    Material green;
    [SerializeField]
    Material red;
    RaycastHit hit;
    [SerializeField]
    GameObject pauseCanvas;

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
                if (hit.collider.gameObject.tag == "PlayerControlled")
                {
                    if (Input.GetAxis("MultiSelect") > 0)
                    {
                        hit.collider.gameObject.GetComponent<PlayerGuyScript>().selectedIndicator.GetComponent<MeshRenderer>().sharedMaterial = green;
                        agents.Add(hit.collider.gameObject.GetComponent<NavMeshAgent>());
                    }
                    else
                    {
                        foreach (var item in agents)
                        {
                            item.GetComponent<PlayerGuyScript>().selectedIndicator.GetComponent<MeshRenderer>().sharedMaterial = red;
                        }
                        hit.collider.gameObject.GetComponent<PlayerGuyScript>().selectedIndicator.GetComponent<MeshRenderer>().sharedMaterial = green;
                        agents.Clear();
                        agents.Add(hit.collider.gameObject.GetComponent<NavMeshAgent>());
                    }
                }
                else if (hit.collider.gameObject.tag == "Floor" && agents.Count > 0)
                {
                    for (int i = 0; i < agents.Count; i++)
                    {
                        agents[i].stoppingDistance = 0;
                        agents[i].destination = hit.point;
                        agents[i].gameObject.GetComponent<PlayerGuyScript>().target = null;
                    }
                }
                else if (hit.collider.gameObject.tag == "Enemy" && agents.Count > 0)
                {
                    for (int i = 0; i < agents.Count; i++)
                    {
                        agents[i].destination = hit.collider.gameObject.transform.position;
                        agents[i].stoppingDistance = agents[i].GetComponent<PlayerGuyScript>().range;
                        agents[i].gameObject.GetComponent<PlayerGuyScript>().target = hit.collider.gameObject;
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
            if (agents[i].GetComponent<PlayerGuyScript>().target != null && 
                Vector3.Distance(agents[i].GetComponent<PlayerGuyScript>().target.transform.position, agents[i].transform.position) <= 
                agents[i].GetComponent<PlayerGuyScript>().range)
            {
                agents[i].transform.LookAt(agents[i].GetComponent<PlayerGuyScript>().target.transform.position);
                agents[i].gameObject.GetComponent<Animator>().SetBool("Attacking", true);
            }
            else if (agents[i].GetComponent<PlayerGuyScript>().target == null ||
                Vector3.Distance(agents[i].GetComponent<PlayerGuyScript>().target.transform.position, agents[i].transform.position) > 
                agents[i].GetComponent<PlayerGuyScript>().range)
            {
                agents[i].gameObject.GetComponent<Animator>().SetBool("Attacking", false);
            }
        }
        if (Input.mousePosition.y >= Screen.height * 0.95)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * ScrollSpeed, Space.World);
        }
        else if (Input.mousePosition.y <= Screen.height * 0.05)
        {
            transform.Translate(Vector3.forward * -Time.deltaTime * ScrollSpeed, Space.World);
        }
        else if (Input.mousePosition.x >= Screen.width * 0.95)
        {
            transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
        }
        else if (Input.mousePosition.x <= Screen.width * 0.05)
        {
            transform.Translate(Vector3.right * -Time.deltaTime * ScrollSpeed, Space.World);
        }
        if (Input.GetAxis("TogglePauseMenu") > 0)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
