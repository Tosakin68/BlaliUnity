using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedByBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.InstantKillEnemy(gameObject, collision.gameObject);
        }
    }
}
