using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public AudioClip shootsound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootGun();
    }

    void ShootGun()
    {
        if(Input.GetKeyDown(KeyCode.Space) && GameManager.bullets > 0)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            GameManager.bullets--;
            AudioSource sfx = gameObject.AddComponent<AudioSource>();
            sfx.clip = shootsound;
            sfx.volume = 0.3f;
            sfx.Play();
            Destroy(sfx, sfx.clip.length);
        }
    }
}
