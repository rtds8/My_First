using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Pool_Creator : MonoBehaviour
{
    [SerializeField] private GameObject m_bullet;
    [SerializeField] private int m_No_Of_Bullets = 10, m_ScreenBound = 0;
    [SerializeField] private float m_bulletSpeed = 1f, m_recoilTime=0f;
    [HideInInspector] private float m_nextFire = 4f;

    List<GameObject> Bullet_Pool;
    void Start()
    {
        Bullet_Pool = new List<GameObject>();
        for (int i = 0; i < m_No_Of_Bullets; i++)
        {
            GameObject objBullet = Instantiate(m_bullet);
            objBullet.SetActive(false);
            Bullet_Pool.Add(objBullet);
        }
    }
    void FixedUpdate()
    {
        if (Game_Manager.instance._startFiring > m_nextFire)
        {
            GenerateBullet();
            m_nextFire+= m_recoilTime;
        }

        for (int i=0; i<Bullet_Pool.Count; i++)
        {
            if(Bullet_Pool[i].transform.position.z > m_ScreenBound && Bullet_Pool[i].activeInHierarchy)
                Bullet_Pool[i].SetActive(false);
        }
    }

    private void GenerateBullet()
    {
        for (int i = 0; i < Bullet_Pool.Count; i++)
        {
            if (!Bullet_Pool[i].activeInHierarchy)
            {
                Bullet_Pool[i].transform.position = transform.position;
                Bullet_Pool[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, m_bulletSpeed);
                Bullet_Pool[i].transform.rotation = transform.rotation;
                Bullet_Pool[i].SetActive(true);
                break;
            }
        }
    }
}
