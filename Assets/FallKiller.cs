using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallKiller : MonoBehaviour
{
    public float MaxY;
    void Update()
    {
        if(transform.position.y < MaxY)
        {
            GameManager.KillPlayer();
        }
    }
}
