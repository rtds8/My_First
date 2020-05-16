using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Transform m_transform;
    [SerializeField] private float m_Speed = 1f, leftlimit = 1f, rightlimit = 1f, toplimit = 1f, bottomlimit = 1f;
    [SerializeField] private GameObject m_PlayerBulletsLeft, m_PlayerBulletsRight;
    [SerializeField] private Transform m_Engine;
    void Start()
    {
        m_transform = this.transform;
    }
    
    void FixedUpdate()
    {
        if(Game_Manager.instance._gamePlaying)
        {
            GetInput();
        }
    }

    private void GetInput()
    {
        if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && (m_transform.position.x < rightlimit))
        {
            MoveHorizontal(1);
        }
        
        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && (m_transform.position.x > leftlimit))
        {
            MoveHorizontal(-1);
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && (m_transform.position.z < toplimit))
        {
            MoveVertical(1);
        }

        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && (m_transform.position.z > bottomlimit))
        {
            MoveVertical(-1);
        }

    }

    private void MoveHorizontal(int Direction)
    {
        m_transform.Translate(Vector3.right * Direction * m_Speed );
        m_PlayerBulletsLeft.transform.Translate(Vector3.right * Direction * m_Speed);
        m_PlayerBulletsRight.transform.Translate(Vector3.right * Direction * m_Speed);
        m_Engine.Translate(Vector3.right * Direction * m_Speed);
    }

    private void MoveVertical(int Direction)
    {
        m_transform.Translate(Vector3.up * Direction * m_Speed);
        m_PlayerBulletsLeft.transform.Translate(Vector3.up * Direction * m_Speed);
        m_PlayerBulletsRight.transform.Translate(Vector3.up * Direction * m_Speed);
        m_Engine.Translate(Vector3.up * Direction * m_Speed);
    }
}
