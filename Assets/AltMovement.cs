using UnityEngine;

public class AltMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private Vector2 jump;
    [SerializeField] private bool isGrounded = false;

    private float playerSpeedbackup;
    private Rigidbody2D _playerRigidbody;
    private SpriteRenderer _sr;
    private Animator _animator;
    private AudioSource sfx;
    private void Start()
    {
        playerSpeedbackup = playerSpeed;
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
        _sr = GetComponent<SpriteRenderer>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
        jump = new Vector2(0, 1);
    }
    private void Update()
    {
        Flipper();
        MovePlayer();
        Fart();
        Jump();
    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
        if(horizontalInput != 0 && !Input.GetButton("Vertical"))
        {
            _animator.SetInteger("state", 0);
        }
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            _animator.SetInteger("state", 1);
            _playerRigidbody.AddForce(jump * jumpPower);
        }
    }

    private void Fart()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody2D rgb = GetComponent<Rigidbody2D>();
        if (Input.GetAxis("Vertical") < 0 && Input.GetButton("Vertical"))
        {
            if(!sfx.isPlaying)
            {
                sfx.Play();
            }
            _animator.SetInteger("state", 2);
            playerSpeed = 3f;
            rgb.gravityScale = 0.1f;
            rgb.velocity = new Vector2(rgb.velocity.x, -0.2f);
        }
        else
        {
            if(playerSpeed != playerSpeedbackup)
            {
                _animator.SetInteger("state", 0);
                sfx.Stop();
                playerSpeed = playerSpeedbackup;
                rgb.gravityScale = 1;
            }
        }
    }

    private void Flipper()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            _sr.flipX = false;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            _sr.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
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