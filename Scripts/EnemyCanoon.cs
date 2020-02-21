using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanoon : MonoBehaviour {
    public GameObject bullet;
    public int WaitForNextShot;
    // Use this for initialization
    void Start () {
        InvokeRepeating("normalFire", 1, WaitForNextShot);
    }
	
	// Update is called once per frame
	void Update () {
    }
    
    void normalFire()
    {
        Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

    }
}
