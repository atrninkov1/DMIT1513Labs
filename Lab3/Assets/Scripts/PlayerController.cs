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
    public GameObject selected;
    [SerializeField]
    GameObject flag;
    private bool isSelecting;
    static Texture2D _whiteTexture;
    public static Texture2D WhiteTexture
    {
        get
        {
            if (_whiteTexture == null)
            {
                _whiteTexture = new Texture2D(1, 1);
                _whiteTexture.SetPixel(0, 0, Color.white);
                _whiteTexture.Apply();
            }

            return _whiteTexture;
        }
    }

    Vector3 mousePosition1;

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
                    selected = hit.collider.gameObject;
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
                    selected = hit.collider.gameObject;
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

        for (int i = 0; i < agents.Count; i++)
        {
            GameObject indicator = Instantiate(flag);
            indicator.transform.position = agents[i].destination;
        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition1 = Input.mousePosition;
            isSelecting = true;
        }

        if (Input.GetMouseButtonUp(0))
            isSelecting = false;

        GameObject[] playerMinions = GameObject.FindGameObjectsWithTag("PlayerControlled");


    }
    void DrawScreenRect(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.DrawTexture(rect, WhiteTexture);
        GUI.color = Color.white;
    }

    void DrawScreenRectBorder(Rect rect, float thickness, Color color)
    {
        // Top
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
        // Left
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
        // Right
        DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
        // Bottom
        DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
    }

    Rect GetScreenRect(Vector3 screenPosition1, Vector3 screenPosition2)
    {
        // Move origin from bottom left to top left
        screenPosition1.y = Screen.height - screenPosition1.y;
        screenPosition2.y = Screen.height - screenPosition2.y;
        // Calculate corners
        var topLeft = Vector3.Min(screenPosition1, screenPosition2);
        var bottomRight = Vector3.Max(screenPosition1, screenPosition2);
        // Create Rect
        return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
    }

    Bounds GetViewportBounds(Vector3 screenPosition1, Vector3 screenPosition2)
    {
        var v1 = Camera.main.ScreenToViewportPoint(screenPosition1);
        var v2 = Camera.main.ScreenToViewportPoint(screenPosition2);
        var min = Vector3.Min(v1, v2);
        var max = Vector3.Max(v1, v2);
        min.z = Camera.main.nearClipPlane;
        max.z = Camera.main.farClipPlane;

        var bounds = new Bounds();
        bounds.SetMinMax(min, max);
        return bounds;
    }

    bool IsWithinSelectionBounds(GameObject gameObject)
    {
        if (!isSelecting)
            return false;

        var camera = Camera.main;
        var viewportBounds = GetViewportBounds(mousePosition1, Input.mousePosition);

        return viewportBounds.Contains(
            camera.WorldToViewportPoint(gameObject.transform.position));
    }

    void OnGUI()
    {
        if (isSelecting)
        {
            // Create a rect from both mouse positions
            var rect = GetScreenRect(mousePosition1, Input.mousePosition);
            DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }
}
