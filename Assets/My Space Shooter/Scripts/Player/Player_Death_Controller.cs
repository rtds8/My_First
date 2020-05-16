using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Player_Death_Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_healthValueText;
    [SerializeField] private Slider m_healthBar;
    [SerializeField] private GameObject m_game_over_screen, m_ship_damage_explosion, m_bullet_damage_explosion ,m_playerShipBlast;
    private GameObject m_enemyObject;
    private bool m_hasCollided = false;

    private void Start()
    {
        m_healthBar.value = Game_Manager.instance._playerHealth;

        m_healthValueText.text = Game_Manager.instance._playerHealth.ToString() + "%";
    }

    private void OnTriggerEnter(Collider other)
    {
        m_enemyObject = other.gameObject;

        m_hasCollided = true;
    }

    private void FixedUpdate()
    {
        m_healthBar.value = Game_Manager.instance._playerHealth;

        m_healthValueText.text = Game_Manager.instance._playerHealth.ToString("0") + "%";

        if (m_enemyObject != null && m_enemyObject.CompareTag("Enemy_Bullet") && m_hasCollided)
        {
            Audio_Manager.instance.Play_Audio("health_decrement");

            Game_Manager.instance._playerHealth -= Game_Manager.instance._playerHealth * 0.05f;

            Instantiate(m_bullet_damage_explosion, m_enemyObject.transform.position, m_enemyObject.transform.rotation);
            
            m_enemyObject.SetActive(false);

            m_hasCollided = false;
        }

        if (m_enemyObject != null && m_enemyObject.CompareTag("Enemy_Ship") && m_hasCollided)
        {
            Audio_Manager.instance.Play_Audio("health_decrement");

            Game_Manager.instance._playerHealth /= 2;

            Instantiate(m_ship_damage_explosion, m_enemyObject.transform.position, m_enemyObject.transform.rotation);

            m_hasCollided = false;
        }

        if (Game_Manager.instance._playerHealth <= 1)
        {
            m_healthBar.value = 0;

            m_healthValueText.text = "0%";

            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        Instantiate(m_playerShipBlast, transform.position, transform.rotation);

        yield return new WaitForSeconds(0.2f);

        Game_Manager.instance.End();

        Audio_Manager.instance.Play_Audio("game_over");

        m_game_over_screen.SetActive(true);
    }
}
