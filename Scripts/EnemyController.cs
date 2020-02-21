using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    //Public Variables 
    public float health;
    public float speed;
    public float powerForEachKill;
    public float damageOnHit;
    public Animator anim;
    public enum MovementOptions {
        Movemen1,
        Movement2
    };
    public MovementOptions EnemyMovement;
    //Private Variables 
    private float pheta = 0;
    private float rand;
    private int Alpha = 1;
    private float orignalHealth;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rand = Random.Range(0, 12);
        orignalHealth = health;
    }
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            anim.SetTrigger("Dead");
        }

       if(transform.position.y <= -15)
        {
            Destroy(gameObject);
            GameObject.Find("EarthHealth").GetComponent<Slider>().value -= 1;
        }

        switch (EnemyMovement) {
            case MovementOptions.Movemen1:
                DownMovement();
                break;
            case MovementOptions.Movement2:
                BossMovement1();
                break;
        }
        if(gameObject.name.Contains("Enemy Boss 1") && health <= orignalHealth*0.3)
        {
            anim.SetTrigger("LowHealth");
        }

    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag.Equals("PlayerBullet"))
        {
            health -= GameObject.Find("Player").GetComponent<PlayerController>().damage;
            anim.SetTrigger("Hit");
            Destroy(col.gameObject);
            Debug.Log("HIT");
        }
    }

    public void destroyEnemy()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().power += powerForEachKill;
        Destroy(gameObject);
    }

    public void deathSoundEnemy()
    {
        SoundManager.PlaySound("EnemyDeath");
    }

    public void DownMovement()
    {
        transform.Translate(Vector2.down * speed * Time.timeScale, Space.World);
    }

    public void BossMovement1()
    {
        transform.rotation = GameObject.Find("Player").transform.rotation;
        if (transform.position.y > 13)
        {
            transform.Translate(Vector2.down * speed * Time.timeScale, Space.World);
        }
        if(transform.position.x >= 36)
        {
            Alpha = -1;
        }

        if (transform.position.x <= -36)
        {
            Alpha = 1;
        }

        Vector2 pos = new Vector2(transform.position.x + (speed * Mathf.Sin(Alpha) * Time.timeScale), transform.position.y);
        transform.position = pos;
    }
    /*public void WaveMovement()
    {
        pheta += speed;
        Vector2 vect2 = new Vector2(Mathf.Sin(pheta) * rand, transform.position.y - speed);

        transform.Translate(Vector2.down * speed,Space.World);
        transform.Translate(Vector2.right * Mathf.Sin(pheta) * speed * rand, Space.World);
    }*/
}
