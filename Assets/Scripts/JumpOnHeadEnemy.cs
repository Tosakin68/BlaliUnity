using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnHeadEnemy : MonoBehaviour
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
        move = new Vector2(1, 0);
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
        if (transform.position.x <= startingpos.x - movelength)
        {
            Moving = true;
        }
        if (transform.position.x >= startingpos.x + movelength)
        {
            Moving = false;
        }
    }

    void Move()
    {
        if (Moving == false)
        {
            transform.Translate(-move * movespeed * Time.deltaTime);
            if (FlipX)
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
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.point.y > transform.position.y + 0.5)
                {
                    Vector3 newscale = new Vector3(transform.localScale.x, 0.014214f, transform.localScale.z);
                    Vector3 newpos = new Vector3(transform.position.x, transform.position.y - 0.16f, transform.position.z);
                    gameObject.transform.localScale = newscale;
                    transform.position = newpos;
                    Destroy(polygonCollider2D);
                    sfx.Play();
                    Destroy(gameObject, sfx.clip.length);
                    return;
                }
            }
            GameManager.KillPlayer();
        }
    }
}
