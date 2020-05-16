using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy_Death_Controller : MonoBehaviour
{
    private GameObject m_collidedObject;
    private bool m_hitByPlayer = false;
    [SerializeField] private GameObject m_explosion;
    private void OnTriggerEnter(Collider other)
    {
        m_collidedObject = other.gameObject;
        m_hitByPlayer = true;
    }

    private void FixedUpdate()
    {
        if (m_collidedObject!=null && (m_collidedObject.CompareTag("Player_Bullet") || m_collidedObject.CompareTag("Player_Ship")) && m_hitByPlayer)
        {
            Audio_Manager.instance.Play_Audio("score_increment");

            Game_Manager.instance._currentScore++;

            if (Game_Manager.instance._currentScore > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", Game_Manager.instance._currentScore);
            }
               
            if(m_collidedObject.CompareTag("Player_Bullet"))
                m_collidedObject.SetActive(false);

            Instantiate(m_explosion, transform.position, transform.rotation);

            this.gameObject.SetActive(false);

            m_hitByPlayer = false;
        }
    }
}
