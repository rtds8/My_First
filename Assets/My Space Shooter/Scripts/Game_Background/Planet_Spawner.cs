using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Spawner : MonoBehaviour
{
    [SerializeField] private float m_Min = -1f, m_Max = 1f;
    private float m_rand_pos;
    void Start()
    {
        m_rand_pos = Random.Range(m_Min, m_Max);
        transform.position = new Vector3(m_rand_pos, transform.position.y, transform.position.z);
    }

    private void OnEnable()
    {
        Invoke("Hide_Planet", 11.5f);
    }

    void Hide_Planet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
