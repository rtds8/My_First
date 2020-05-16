using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_To_Bullet_Collision : MonoBehaviour
{
    private GameObject m_enemyBullet;
    private bool m_bulletCollided = false;
    [SerializeField] private GameObject m_bulletExplosion;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy_Bullet"))
        {
            m_enemyBullet = other.gameObject;

            m_bulletCollided = true;
        }
    }

    private void FixedUpdate()
    {
        if(m_enemyBullet!=null && m_enemyBullet.CompareTag("Enemy_Bullet") && m_bulletCollided)
        {
            Instantiate(m_bulletExplosion, transform.position, transform.rotation);

            m_enemyBullet.SetActive(false);

            this.gameObject.SetActive(false);

            m_bulletCollided = false;
        }
    }
}
