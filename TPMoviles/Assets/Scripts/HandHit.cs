using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandHit : MonoBehaviour {

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            player.GetComponent<PlayerLife>().lives--;
         
    }

  



}
    

