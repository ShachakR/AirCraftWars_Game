using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannons : MonoBehaviour {
    public GameObject EqupiedBullet;
    public GameObject RoundShot;
    GameObject OriginalBullet; 
    // Use this for initialization
    float timer;
    [HideInInspector]
    bool AbilityActive; 
    void Start () {
        OriginalBullet = EqupiedBullet;
        AbilityActive = false;

    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(timer);

        if (timer > 0)
        {
            if (AbilityActive == true)
            {
                StartCoroutine("CountDownTimer");
                AbilityActive = false;
            }
        }

        if(timer <= 0)
        {
            NormalShot();
        }

        FireShot();

    }

    IEnumerator CountDownTimer()
    {
        while (timer>0)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1;
        }
        yield break;
    }

    void FireShot()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SoundManager.PlaySound("LaserShot");
            Instantiate(EqupiedBullet, new Vector2(transform.position.x,transform.position.y), Quaternion.identity);
        }
    }

    public void RoundShotFire()
    {
        AbilityActive = true;
        timer = 10;
        GameObject.Find("Player").GetComponent<PlayerController>().damage = 10;
        EqupiedBullet = RoundShot;
    }

    void NormalShot()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().damage = 50;
        EqupiedBullet = OriginalBullet;
    }
}
