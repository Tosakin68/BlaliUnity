using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollision : MonoBehaviour
{
    AudioSource sfx;
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sfx.Play();
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            PolygonCollider2D pc = GetComponent<PolygonCollider2D>();
            sr.enabled = false;
            pc.enabled = false;
            GameManager.bullets += 5;
        }
    }
}
