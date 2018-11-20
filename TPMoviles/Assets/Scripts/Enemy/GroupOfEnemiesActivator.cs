using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroupOfEnemiesActivator : MonoBehaviour {

    Vector3 origin;
    GameObject player;
    Quaternion rotation;   
    PlayerMovement pm;
    NavMeshAgent agent;
    bool rotated = false;
   
    public float rotationSpeed = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            GroupOfEnemiesManager.Instance.ActivateGroup();
            pm.arrived = true;           
            agent.enabled = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pm.arrived = false;            
        }
    }

    private void Awake()
    {        
        origin = -transform.right;
        rotation = Quaternion.LookRotation(origin,Vector3.up);
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        agent = player.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Debug.Log("ARRIVED" + pm.arrived);
        Debug.Log("FIGHTING" + pm.fighting);
        if (!rotated)
            RotatePlayer();

        if (player.transform.rotation == rotation)
        {
            rotated = true;
            agent.enabled = true;
            pm.arrived = false;
        }
    }

    private void RotatePlayer()
    {
        
        if (pm.arrived)
        {
            Debug.Log(origin);
            Debug.Log("ENTRE A LA FUNC ROTATION");
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
       
    }
}
