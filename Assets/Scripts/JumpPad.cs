using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpPower;
    AudioSource sfx;
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.point.y > transform.position.y)
                {
                    Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                    rb.velocity = Vector2.zero;
                    sfx.Play();
                    rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                }
            }
        }
    }
}
