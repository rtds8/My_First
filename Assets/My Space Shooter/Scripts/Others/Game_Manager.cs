using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    [HideInInspector] public float _elapsedTime;
    [HideInInspector] public float  _startFiring{ get; private set; }
    public bool _gamePlaying { get; private set; }
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [HideInInspector] public int _currentScore = 0;
    [HideInInspector] public float _playerHealth = 100;
    [SerializeField] private GameObject m_player;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        _gamePlaying = false;
    }

    public void Begin()
    {
        _gamePlaying = true;
        _elapsedTime = Time.time;
    }

    void FixedUpdate()
    {
        m_scoreText.text = "Score:  " + _currentScore.ToString();

        if (_gamePlaying)
        {
            _startFiring = Time.time;
        }
    }

    public void End()
    {
        m_player.SetActive(false);

        _gamePlaying = false;

        if (PlayerPrefs.GetInt("SavedProgress") != 0)
        {
            PlayerPrefs.DeleteKey("SavedProgress");
        }

        Invoke("Restart", 2f);
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
