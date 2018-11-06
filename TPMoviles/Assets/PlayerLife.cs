using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {

    [SerializeField] public int lives;

	void Start () {
		
	}
	
	void Update () {
        if (lives==0)
        {
            SceneManager.LoadScene("GameOver");
        }
	}
}
