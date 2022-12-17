using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeathOnCollision : MonoBehaviour
{
    public GameObject player;
    private Vector2 spawnlocation;
    bool Timing = false;
    float timer = 10;
    Vector2 PlayerPosition = Vector2.zero;
    public AudioSource augh;
    // Start is called before the first frame update
    void Start()
    {
        spawnlocation = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        if (timer <= 1)
        {
            player.transform.position = spawnlocation;
            timer = 10;
            Timing = false;
        }
        if(augh.isPlaying)
        {
            Vector2 PlayerPosition = player.transform.position;
            player.transform.position = PlayerPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 PlayerPosition = player.transform.position;
            Timing = true;
            augh.Play();
        }
    }

    void Timer()
    {
        if((Timing == true) && (!augh.isPlaying))
        {
            player.transform.position = PlayerPosition;
            while (timer > 1)
            {
                timer = timer - Time.deltaTime;
                Debug.Log(timer);
            }
            Timing = false;
        }
    }
}
