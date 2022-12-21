using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reball : MonoBehaviour
{
    Vector2 startingpos;
    Vector2 move;
    public float movespeed;
    public float movelength;
    public bool FlipX;
    bool Moving = false;
    AudioSource sfx;
    PolygonCollider2D polygonCollider2D;
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        startingpos = transform.position;
        move = new Vector2(0, 1);
        sfx = GetComponent<AudioSource>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Booling();
        Move();
    }

    void Booling()
    {
        if(transform.position.y <= startingpos.y - movelength)
        {
            Moving = true;
        }
        if (transform.position.y >= startingpos.y + movelength)
        {
            Moving = false;
        }
    }

    void Move()
    {
        if(Moving == false)
        {
            transform.Translate(-move * movespeed * Time.deltaTime);
            if(FlipX)
            {
                spriteRenderer.flipX = false;
            }
        }
        if (Moving == true)
        {
            transform.Translate(move * movespeed * Time.deltaTime);
            if (FlipX)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.KillPlayer();
        }
    }
}
