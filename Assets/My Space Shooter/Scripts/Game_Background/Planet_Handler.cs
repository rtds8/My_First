using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Handler : MonoBehaviour
{
    [SerializeField] private GameObject m_Planet_1, m_Planet_2, m_Planet_3, m_Planet_4;
    private int m_random_planet;

    private IEnumerator Start()
    {
        while (true)
        {
            m_random_planet = Random.Range(1, 5);

            if (m_random_planet == 1 && !m_Planet_1.activeInHierarchy)
                m_Planet_1.SetActive(true);

            else if (m_random_planet == 2 && !m_Planet_2.activeInHierarchy)
                m_Planet_2.SetActive(true);

            else if (m_random_planet == 3 && !m_Planet_3.activeInHierarchy)
                m_Planet_3.SetActive(true);

            else if (m_random_planet == 4 && !m_Planet_4.activeInHierarchy)
                m_Planet_4.SetActive(true);

            else
                continue;

            yield return new WaitForSeconds(8f);
        }

    }

}
