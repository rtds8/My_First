using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Countdown_Controller : MonoBehaviour
{
    [SerializeField] private int m_countdownTime = 3;
    [SerializeField] private TextMeshProUGUI m_countdownText;

    void Start()
    {
        StartCoroutine(CountdownStart());
        Audio_Manager.instance.Play_Audio("countdown");
    }

    IEnumerator CountdownStart()
    {
        while(m_countdownTime>0)
        {
            m_countdownText.text = m_countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            m_countdownTime--;
        }

        m_countdownText.text = "GO!!";
        yield return new WaitForSeconds(0.8f);
        m_countdownText.gameObject.SetActive(false);
        Game_Manager.instance.Begin();
    }
}
