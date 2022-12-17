using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathOnCollision : MonoBehaviour
{
    GameObject DeathSound;
    AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        DeathSound = GameObject.FindGameObjectWithTag("DeathSound");
        sfx = DeathSound.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            sfx.Play();
            DontDestroyOnLoad(DeathSound);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
