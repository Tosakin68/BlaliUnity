using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveTowardsPlayer : MonoBehaviour
{
    public float bulletspeed;
    GameObject Player;
    Rigidbody2D rb;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        GetWay();
        Invoke("DestroySelf", 2.0f);
        
    }

    void Update()
    {
        transform.Translate(direction * bulletspeed * Time.deltaTime);
    }

    void GetWay()
    {
        direction = (Player.transform.position - transform.position).normalized;
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.KillPlayer();
        }
        else if (collision.gameObject.CompareTag("DestroyBullet"))
        {
            Destroy(gameObject);
        }
    }
}
