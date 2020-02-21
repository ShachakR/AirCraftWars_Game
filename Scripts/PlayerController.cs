using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    public float speed;
    public float damage;
    public Slider playerHealth;
    public Slider AbilityPower;
    public Slider EarthHealth;
    public float health;
    public float power;
    Animator anim;
    [HideInInspector]
    public float KillCount;
    public float skillPoints; 
    // Use this for initialization
    void Start () {
        playerHealth.maxValue = 100;
        playerHealth.value = 100;
        AbilityPower.value = 0;
        health = 100;
        power = 0;
        skillPoints = 1;
        anim = GameObject.Find("SpaceShip").GetComponent<Animator>();
        EarthHealth.value = 100;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
        transform.position += (playerPos * speed);
        playerHealth.value = health;
        AbilityPower.value = power;

        if(power > 100)
        {
            power = 100;
        }

        if(health < 0)
        {
            health = 0;
        }

        if (transform.position.y <= -8)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }

        if (transform.position.y >=16)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        }

        if (transform.position.x >= 52)
        {
            transform.position = new Vector2(-50, transform.position.y);
        }
        if (transform.position.x <= -52)
        {
            transform.position = new Vector2(50, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("EnemyBullet"))
        {
            Destroy(col.gameObject);
            SoundManager.PlaySound("PlayerHit");
            health -= 3;
            anim.SetTrigger("Hit");
        }
        if (col.gameObject.name.Equals("Boss 1 Bullet"))
        {
            SoundManager.PlaySound("PlayerHit");
            health -= 10;
            anim.SetTrigger("Hit");
        }
        if (col.gameObject.name.Contains("Asteroid"))
        {
            SoundManager.PlaySound("PlayerHit");
            health -= col.gameObject.GetComponent<AsteroidController>().damage;
        }

        if (col.gameObject.name.Contains("Enemy"))
        {
            SoundManager.PlaySound("PlayerHit");
            health -= col.gameObject.GetComponent<EnemyController>().damageOnHit;
        }

    }
}
