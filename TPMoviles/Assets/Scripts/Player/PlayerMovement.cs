using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {


    [SerializeField] GameObject[] waypointsArray;
    private int CurrentWaypoint = 0;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        agent.SetDestination(waypointsArray[CurrentWaypoint].transform.position);
    }
    
    public void Walk()
    {
        agent.SetDestination(waypointsArray[CurrentWaypoint].transform.position);
    }
    public void SetNextWaypoint()
    {       
        CurrentWaypoint++;
    }
}
