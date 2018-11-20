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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        agent.SetDestination(waypointsArray[CurrentWaypoint].transform.position);
    }

    public void SetNextWaypoint()
    {       
        CurrentWaypoint++;        
    }
}
