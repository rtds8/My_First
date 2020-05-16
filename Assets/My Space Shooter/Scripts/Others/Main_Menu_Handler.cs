using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu_Handler : MonoBehaviour
{
    [SerializeField] private GameObject m_loadingScreeen;
    [SerializeField] private GameObject m_mainMenu;
    [SerializeField] private GameObject m_continueButton;
    [SerializeField] private Scene_Loader setSceneIndex;

    private void start()
    {
        if (PlayerPrefs.GetInt("SavedProgress") != 0)
            m_continueButton.SetActive(true);
    }

    public void OnHover()
    {
        Audio_Manager.instance.Play_Audio("button_sound");
    }

    public void OnClick()
    {
        Audio_Manager.instance.Play_Audio("button_click");
    }
    
    public void OnClickContinue()
    {
        setSceneIndex._sceneToBeLoaded = PlayerPrefs.GetInt("SavedProgress");
        m_loadingScreeen.SetActive(true);
        m_mainMenu.SetActive(false);
    }

    public void OnClickNewGameButton()
    {
        if (PlayerPrefs.GetInt("SavedProgress") != 0)
        {
            PlayerPrefs.DeleteKey("SavedProgress");
        }
        setSceneIndex._sceneToBeLoaded = SceneManager.GetActiveScene().buildIndex + 1;
        m_loadingScreeen.SetActive(true);
        m_mainMenu.SetActive(false);
    }

    public void OnClickQuitButton()
    {
        if (PlayerPrefs.GetInt("SavedProgress") != 0)
        {
            PlayerPrefs.DeleteKey("SavedProgress");
        }
        Application.Quit();
    }
}
