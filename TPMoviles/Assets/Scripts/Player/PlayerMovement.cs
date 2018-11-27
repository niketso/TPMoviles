using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {


    [SerializeField] GameObject[] waypointsArray;
    private int CurrentWaypoint = 0;
    NavMeshAgent agent;
    CameraLook cam;
    public bool arrived = false;
    public bool fighting = false;
    public bool walking=false;
    public bool lastWaypoint = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = GetComponentInChildren<CameraLook>();
        
    }
    private void Start()
    {
        Walk();
    }

    public void Walk()
    {
        if (waypointsArray[CurrentWaypoint].transform.name!=("Wayp1"))
        {
            if(waypointsArray[CurrentWaypoint-1])
                waypointsArray[CurrentWaypoint - 1].transform.gameObject.SetActive(false);
        }

        if (lastWaypoint == false)
        {
            walking = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            agent.SetDestination(waypointsArray[CurrentWaypoint].transform.position);
        }
    }

    public void SetNextWaypoint()
    {       
        CurrentWaypoint++;        
    }
}
