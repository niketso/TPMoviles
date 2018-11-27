using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateLives : MonoBehaviour
{
    [SerializeField] string nextLevel;
    public int lifePlayer;
    public Text lifeValue;

    void Update()
    {
        lifePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>().lives;
        lifeValue.text = lifePlayer.ToString();
        if (lifePlayer == 0)
        {
            SceneManager.LoadScene(nextLevel);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}