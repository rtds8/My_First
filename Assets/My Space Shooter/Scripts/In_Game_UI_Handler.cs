using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class In_Game_UI_Handler : MonoBehaviour
{
    public static bool _isGamePaused = false;
    [SerializeField] private GameObject m_pauseMenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isGamePaused)
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
        m_pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        _isGamePaused = false;
    }
    void Pause()
    {
        m_pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _isGamePaused = true;
    }

    public void OnClickMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnClickQuit()
    {
        Debug.Log("Game Quitted"); //To know that the next statement is working or not, because the effect of the next statement cannot be understood in unity engine.
        Application.Quit();
    }
}

