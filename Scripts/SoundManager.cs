using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, EnemyDeathSound, laserShotSound, powerUpSound, ShieldHitSound;
    static AudioSource audiosrc;
    // Use this for initialization
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("PlayerHit");
        EnemyDeathSound = Resources.Load<AudioClip>("EnemyDeath");
        laserShotSound = Resources.Load<AudioClip>("LaserShot");
        powerUpSound = Resources.Load<AudioClip>("PowerUp");
        ShieldHitSound = Resources.Load<AudioClip>("ShieldHit");

        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "PlayerHit":
                audiosrc.PlayOneShot(playerHitSound);
                break;
            case "EnemyDeath":
                audiosrc.PlayOneShot(EnemyDeathSound);
                break;
            case "LaserShot":
                audiosrc.PlayOneShot(laserShotSound);
                break;
            case "PowerUp":
                audiosrc.PlayOneShot(powerUpSound);
                break;
            case "ShieldHit":
                audiosrc.PlayOneShot(ShieldHitSound);
                break;
        }
    }
}
