using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    [SerializeField] private GameObject m_EnemyShip;
    [SerializeField] private int m_No_Of_Enemies = 1;
    [SerializeField] private float  m_SpawnRate = 1f;
    private int m_randposition=0;

    List<GameObject> EnemyWave;
    void Start()
    {
        EnemyWave = new List<GameObject>();
        for(int i=0;i<m_No_Of_Enemies;i++)
        {
            GameObject objEnemy = Instantiate(m_EnemyShip);
            objEnemy.SetActive(false);
            EnemyWave.Add(objEnemy);
            objEnemy.transform.parent = this.transform;
        }
    }
    void FixedUpdate()
    {
        if(Time.time > Game_Manager.instance._elapsedTime && Game_Manager.instance._gamePlaying)
        {
            Generate();
            Game_Manager.instance._elapsedTime += m_SpawnRate;
        }
        for (int j = 0; j < EnemyWave.Count; j++)
        {
            if (EnemyWave[j].transform.position.z < (-11) && EnemyWave[j].activeInHierarchy)
            {
                EnemyWave[j].SetActive(false);
            }
        }
    }

    private void Generate()
    {
        for(int i=0;i<EnemyWave.Count;i++)
        {
            if(!EnemyWave[i].activeInHierarchy)
            {
                m_randposition = Random.Range(-6, 7);
                EnemyWave[i].transform.position = new Vector3(m_randposition, transform.position.y, transform.position.z);
                EnemyWave[i].transform.rotation = transform.rotation;
                EnemyWave[i].SetActive(true);
                break;
            }
        }
    }
}
