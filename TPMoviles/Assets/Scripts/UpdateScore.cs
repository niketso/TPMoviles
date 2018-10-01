using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateScore : MonoBehaviour {
	[SerializeField] string nextLevel;
    //private Destructor score;
    public Text scoreText;

	[SerializeField] public int maxScore;
    private int score;

	public int Score{
		get{ return score;}
		set{score = value;}
	}

	void Start () {	
		//score = GameObject.FindGameObjectWithTag ("Bullet").GetComponent<Destructor> ();
	}

	void Update(){
		
		if (score == maxScore)
			SceneManager.LoadScene (nextLevel);
		
	}
}
