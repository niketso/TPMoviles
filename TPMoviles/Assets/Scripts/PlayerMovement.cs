using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {


    [SerializeField]
    GameObject[] waypointsArray;    
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        agent.SetDestination(waypointsArray[0].transform.position);
    }

    private void Update()
    {
        
    }

    public void Walk()
    {
        agent.SetDestination(waypointsArray[1].transform.position);
    }
}
