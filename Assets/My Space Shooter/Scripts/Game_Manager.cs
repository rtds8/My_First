using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    [HideInInspector] public float _elapsedTime;
    public bool _gamePlaying { get; private set; }
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [HideInInspector] public int _currentScore = 0;

    private void Awake()
    {
        instance = this;
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

    private void Update()
    {
        m_scoreText.text = "Score:  " + _currentScore.ToString();
    }
}
