using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static int bullets;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void KillPlayer()
    {
        GameObject DeathSound = GameObject.FindGameObjectWithTag("DeathSound");
        AudioSource sfx = DeathSound.GetComponent<AudioSource>();
        sfx.Play();
        DontDestroyOnLoad(DeathSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void InstantKillEnemy(GameObject enemy, GameObject bullet)
    {
        if(bullet != null)
        {
            Destroy(bullet);
        }
        SpriteRenderer _spriteRenderer = enemy.GetComponent<SpriteRenderer>();
        Collider2D _collider = enemy.GetComponent<Collider2D>();
        AudioSource _sfx = enemy.GetComponent<AudioSource>();
        _spriteRenderer.enabled = false;
        _collider.enabled = false;
        _sfx.Play();
        Destroy(enemy, _sfx.clip.length);
    }
}
