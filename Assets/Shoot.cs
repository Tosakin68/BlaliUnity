using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
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
        }
    }
}