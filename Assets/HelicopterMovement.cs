using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    private float speed;
    FallKiller fallkiller;
    GameObject helicopter;
    public float minrange;
    public float maxrange;
    bool dead = false;
    private void Start()
    {
        fallkiller = GameObject.FindGameObjectWithTag("Player").GetComponent<FallKiller>();
        helicopter = gameObject;
        speed = Random.Range(1, 1.5f);
    }
    private void Update()
    {
        transform.Translate(new Vector3(-1, -1, 0) * speed * Time.deltaTime);
        if(transform.position.y < fallkiller.MaxY - Random.Range(5, 8) && !dead)
        {
            NewHelicopter();
            Invoke("DestroySelf", 3);
            dead = true;
        }
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private void NewHelicopter()
    {
        Instantiate(helicopter, new Vector2(Random.Range(minrange, maxrange), Random.Range(7, 9)), transform.rotation);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.KillPlayer();
        }
    }
}
