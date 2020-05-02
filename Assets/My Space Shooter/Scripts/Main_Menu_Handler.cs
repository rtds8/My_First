using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu_Handler : MonoBehaviour
{
    public void OnClickPLayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnClickQuitButton()
    {
        Debug.Log("Game Quitted"); //To know that the next statement is working or not, because the effect of the next statement cannot be understood in unity engine.
        Application.Quit();
    }
}
