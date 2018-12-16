using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] private GameObject PauseMenuUI;
 
    public static bool gameIsPaused = false;

    private void Update()
    {
        if (InputManager.Instance.GetPauseButton()/* ||Input.GetKeyDown(KeyCode.Escape)*/)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        
    }  
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
