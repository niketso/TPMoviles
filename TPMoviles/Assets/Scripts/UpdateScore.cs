using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateScore : MonoBehaviour
{
	[SerializeField] string nextLevel;
	[SerializeField] public int maxScore;
    public int score;
    GameObject youWinText;

    private void Awake()
    {
        youWinText = GameObject.Find("YouWinText");
        youWinText.SetActive(false);
    }

    void Update()
    {
        score = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerShoot>().score;

        if (score == maxScore)
        {
            youWinText.SetActive(true);
            Invoke("Win", 5);
        }

    }

    void Win()
    {
        SceneManager.LoadScene(nextLevel);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
