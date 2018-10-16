using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfEnemiesActivator : MonoBehaviour {

    CameraLook cam;
    private void OnTriggerEnter(Collider other)
    {
        GroupOfEnemiesManager.Instance.ActivateGroup();
        cam = other.GetComponent<CameraLook>();
        cam.enabled = true;
        
        
    }
}
