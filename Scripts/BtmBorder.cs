using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtmBorder : MonoBehaviour {
    public Transform [] spawnPoints;
    Transform sp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		sp = spawnPoints[Random.Range(0, spawnPoints.Length)]; 
    }

   void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            collision.transform.position = sp.position;
            Debug.Log("ReSpawn");
       }
    }
}
