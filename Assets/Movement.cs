using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float movespeed;
    public float jumpspeed;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerticalMove();
        HorizontalMove();
        Jump();
        Shift();
    }

    void VerticalMove()
    {
        if (Input.GetButton("Vertical"))
        {
            float Axis = Input.GetAxis("Vertical");
            Vector3 MoveVertical = new Vector3(1, 0, 0);
            transform.Translate(MoveVertical * Axis * movespeed * Time.deltaTime);
        }
    }
    void HorizontalMove()
    {
        if (Input.GetButton("Horizontal"))
        {
            float Axis = Input.GetAxis("Horizontal");
            Vector3 MoveHorizontal = new Vector3(0, 0, -1);
            transform.Translate(MoveHorizontal * Axis * movespeed * Time.deltaTime);
        }
    }
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Vector3 Jump = new Vector3(0, 1, 0);
            rb = GetComponent<Rigidbody>();
            rb.velocity = Jump * jumpspeed;
        }
        
    }

    void Shift()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            movespeed += 1f;
        }
        
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            movespeed -= 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}
