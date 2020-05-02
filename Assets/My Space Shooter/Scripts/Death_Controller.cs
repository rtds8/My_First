using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Controller : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        other.SetActive(false);
        Game_Manager.instance._currentScore++;
    }
}
