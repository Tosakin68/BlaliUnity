using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWay : MonoBehaviour
{
    int WayToGo;
    public float bulletspeed;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 2.0f);
        PlayerCheck();
    }

    // Update is called once per frame
    void Update()
    {
        GetWay();
    }

    void PlayerCheck()
    {
        GameObject player = GameObject.FindWithTag("Player");
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        if(sr.flipX == false)
        {
            WayToGo = 1;
        }
        else
        {
            WayToGo = -1;
        }
    }

    void GetWay()
    {
        Vector2 Way = new Vector2(WayToGo, 0);
        transform.Translate(Way * bulletspeed * Time.deltaTime);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
