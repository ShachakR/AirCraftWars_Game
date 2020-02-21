using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneryShield : MonoBehaviour
{
    public float ShieldHealth;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("Player").transform.position;

        if (ShieldHealth <= 0)
        {
          Destroy(gameObject);
       }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("EnemyBullet"))
        {
            Destroy(col.gameObject);
            SoundManager.PlaySound("ShieldHit");
            ShieldHealth -= 10;
        }
        if(col.gameObject.name.Contains("Boss 1"))
        {
            SoundManager.PlaySound("ShieldHit");
        }
    }
}
