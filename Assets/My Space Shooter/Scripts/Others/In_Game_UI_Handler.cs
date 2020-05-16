using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class In_Game_UI_Handler : MonoBehaviour
{
    public static bool _isGamePaused = false;
    [SerializeField] private GameObject m_pauseMenu;
    [SerializeField] private TextMeshProUGUI m_highScore;

    public void OnHover()
    {
        Audio_Manager.instance.Play_Audio("button_sound");
    }
    public void OnClick()
    {
        Audio_Manager.instance.Play_Audio("button_click");
    }
    void Update()
    {
        m_highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        if (Input.GetKeyDown(KeyCode.Escape) && Game_Manager.instance._gamePlaying)
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
        PlayerPrefs.SetInt("SavedProgress", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}

