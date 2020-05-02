using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Movement : MonoBehaviour
{
    private Transform m_EnemyPosition;
    [SerializeField] private float m_speed=2f;
    [SerializeField] private int m_leftedge=-1, m_rightedge = 1;
    private int m_randomposition=0;

    void Start()
    {
        m_EnemyPosition = this.transform;
        if(Game_Manager.instance._gamePlaying)
        {
            Move();
        }
    }

    void FixedUpdate()
    {
        m_EnemyPosition.position = new Vector3(m_EnemyPosition.position.x, m_EnemyPosition.position.y, m_EnemyPosition.position.z - Time.fixedDeltaTime);
    }

    private void Move()
    {
        m_randomposition = Random.Range(m_leftedge, m_rightedge);
        m_EnemyPosition.DOLocalMoveX(m_randomposition, m_speed, false).OnComplete(() => Move());
    }
}
