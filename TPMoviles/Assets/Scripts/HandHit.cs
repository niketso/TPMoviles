using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandHit : MonoBehaviour {

    GameObject enemy;

        // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {		
	}

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            Debug.Log("MANO CON PLAYER");
            SceneManager.LoadScene("GameOver");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
            Debug.Log("MANO CON PLAYER");
        SceneManager.LoadScene("GameOver");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }



}
    

