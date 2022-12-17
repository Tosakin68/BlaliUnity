using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float movespeed;
    float movespeedbackup;
    public float jumpspeed;
    public int ShiftPlus;
    public bool isGrounded;
    public Sprite fart;
    public Sprite normal;
    public Sprite jumping;
    AudioSource fartsfx;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeedbackup = movespeed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Flip();
        Shift();
        Jump();
        Fart();
    }

    void Movement()
    {
        if(Input.GetButton("Horizontal"))
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalInput * movespeed, rb.velocity.y);
        }
    }

    void Flip()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Shift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movespeed += ShiftPlus;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movespeed -= ShiftPlus;
        }
    }

    void Jump()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Vector2 Jump = new Vector2(0, 1);
            Rigidbody2D rgb = GetComponent<Rigidbody2D>();
            rgb.velocity = (Jump * jumpspeed);
            spriteRenderer.sprite = jumping;
        }
    }

    void Fart()
    {
        AudioSource fartsfx = GetComponent<AudioSource>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody2D rgb = GetComponent<Rigidbody2D>();
        if (Input.GetAxis("Vertical") < 0)
        {
            spriteRenderer.sprite = fart;
            movespeed = 3f;
            rgb.gravityScale = 0.1f;
            rgb.velocity = new Vector2(rb.velocity.x, -0.2f);
        }
        else
        {
        rgb.gravityScale = 1;
        if(spriteRenderer.sprite != normal || jumping)
        {
            spriteRenderer.sprite = normal;
        }
        if(movespeed <= 3)
            {
                movespeed = movespeedbackup;
            }
        }
        if((spriteRenderer.sprite == fart) && !fartsfx.isPlaying)
        {
            fartsfx.Play();
        }
        else
        {
            if(spriteRenderer.sprite != fart)
            {
                fartsfx.Stop();
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
            if(spriteRenderer.sprite == jumping)
            {
                spriteRenderer.sprite = normal;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }
}
