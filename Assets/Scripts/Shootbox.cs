using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootbox : MonoBehaviour
{
    public GameObject evilbullet;
    public AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
        while(gameObject.activeInHierarchy)
        {
            Instantiate(evilbullet, transform.position, transform.rotation);
            if (!sfx.isPlaying)
            {
                sfx.Play();
            }
            yield return new WaitForSeconds(3);
        }
    }
}
