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
}
