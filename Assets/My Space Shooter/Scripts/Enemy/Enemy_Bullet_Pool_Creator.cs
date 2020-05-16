using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_Pool_Creator : MonoBehaviour
{
    [SerializeField] private GameObject m_enemyBullet;
    [SerializeField] private int m_Bullet_Quantity = 10, m_ScreenBound = 0;
    [SerializeField] private float m_speedOfBullet = 1f;

    List<GameObject> Enemy_Bullet_Pool;
    void Start()
    {
        Enemy_Bullet_Pool = new List<GameObject>();
        for (int i = 0; i < m_Bullet_Quantity; i++)
        {
            GameObject objEnemyBullet = Instantiate(m_enemyBullet);
            objEnemyBullet.SetActive(false);
            Enemy_Bullet_Pool.Add(objEnemyBullet);
            objEnemyBullet.transform.parent = this.transform;
        }
    }
    void FixedUpdate()
    {
        if (Game_Manager.instance._gamePlaying)
        {
            GenerateEnemyBullet();
        }

        for (int i = 0; i < Enemy_Bullet_Pool.Count; i++)
        {
            if (Enemy_Bullet_Pool[i].transform.position.z < m_ScreenBound && Enemy_Bullet_Pool[i].activeInHierarchy)
                Enemy_Bullet_Pool[i].SetActive(false);
        }
    }

    private void GenerateEnemyBullet()
    {
        for (int i = 0; i < Enemy_Bullet_Pool.Count; i++)
        {
            if (!Enemy_Bullet_Pool[i].activeInHierarchy)
            {
                Enemy_Bullet_Pool[i].transform.position = transform.position;
                Enemy_Bullet_Pool[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -m_speedOfBullet);
                Enemy_Bullet_Pool[i].transform.rotation = transform.rotation;
                Enemy_Bullet_Pool[i].SetActive(true);
                break;
            }
        }
    }
}
