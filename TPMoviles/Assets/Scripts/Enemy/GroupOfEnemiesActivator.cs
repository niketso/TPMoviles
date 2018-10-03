using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfEnemiesActivator : MonoBehaviour {
   
    private void OnTriggerEnter(Collider other)
    {
        GroupOfEnemiesManager.Instance.ActivateGroup();
        
    }
}
