using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroupOfEnemiesActivator : MonoBehaviour
{

    GameObject player;
    Quaternion rotation;
    PlayerMovement pm;
    NavMeshAgent agent;
    Transform lookAt;
    Transform camera;
    bool rotated = false;

    Quaternion cRotation;
    bool rotateCamera = false;
    bool cameraRotated = false;
    public float rotationSpeed = 10;
    public bool enableUpdate = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            agent.enabled = false;
            enableUpdate = true;
            Debug.Log("COLLISION ----- " + gameObject.name);
            GroupOfEnemiesManager.Instance.ActivateGroup();
            lookAt = gameObject.transform.Find("LookAt");           
            pm.arrived = true;
            pm.walking = false;
            cameraRotated = false;   
            rotated = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pm.arrived = false;
            cameraRotated = true;
            enableUpdate = false;
            Debug.Log("Exited");
        }
    }

    private void Awake()
    {

        // origin = -transform.right;
        player = GameObject.FindGameObjectWithTag("Player");
        camera = player.transform.Find("CameraContainer");
        cRotation = new Quaternion(camera.localRotation.x, camera.localRotation.y, camera.localRotation.z, camera.localRotation.w);
        pm = player.GetComponent<PlayerMovement>();
        agent = player.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!enableUpdate)
            return;
        Debug.Log("ARRIVED" + pm.arrived);
        Debug.Log("FIGHTING" + pm.fighting);
        if (!rotated && pm.arrived && lookAt != null)
            RotatePlayer();

        //Debug.Log("Speed:" + agent.speed + " ---- " + "   CAMERAlocalRot  " + camera.localRotation.y + " -- ROTATECAMERA --" + rotateCamera + "-- CAMERArotated --  " + cameraRotated + "-- WALKING: " + pm.walking);
        if (pm.walking && !rotateCamera && !cameraRotated)
        {
            rotateCamera = true;
        }
        var abs = Mathf.Abs(player.transform.rotation.y - rotation.y);
        LogPlayerRotation();
        //Debug.Log("ABS:" + abs + " done:" + (abs < 0.00001F));
        if (abs < 0.001F)
        {
            rotated = true;
            agent.enabled = true;
            pm.arrived = false;
        }
        else
        {
            if (pm.walking && agent.enabled && rotateCamera)
            {
                AdjustCamera();
            }
        }
    }

    private void LogPlayerRotation()
    {
        //if (lookAt == null)
            //Debug.Log("Rotation:" + player.transform.rotation.y + " => " + rotation.y);
        //else
            //Debug.Log("Rotation:" + player.transform.rotation.y + " => " + rotation.y + "----" + lookAt.position);
    }

    private void AdjustCamera()
    {
        // cRotation = new Quaternion(0.000000001f, 0.000000001f, 0.0000000001f, 0.000000001f);
        camera.localRotation = Quaternion.Lerp(camera.localRotation, cRotation, 50F * Time.deltaTime);
        if (Math.Abs(camera.localRotation.y) < 0.000000001F)
        {
            cameraRotated = true;
            rotateCamera = false;
        }
    }

    private void RotatePlayer()
    {
        //Debug.Log("Rotate Player Method");
        Vector3 direction = lookAt.position - player.transform.position;
        Debug.DrawRay(player.transform.position, direction, Color.red, 10f);
        rotation = Quaternion.LookRotation(direction, Vector3.up);
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
