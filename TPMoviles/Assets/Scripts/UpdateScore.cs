using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateScore : MonoBehaviour {
	[SerializeField] string nextLevel;
	[SerializeField] public int maxScore;
    public int score;

	void Update()
    {
        score = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerShoot>().score;
        if (score == maxScore)
        {
            SceneManager.LoadScene(nextLevel);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
