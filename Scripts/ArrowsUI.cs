using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrowsUI : MonoBehaviour {

    // Use this for initialization
    public GameObject PreviousUnlock;
	void Start () {
        GetComponent<Image>().color = new Color32(255,0,0,80);
	}
	
	// Update is called once per frame
	void Update () {
		if(PreviousUnlock.GetComponent<UnlockScript>().unlocked == true)
        {
            GetComponent<Image>().color = new Color32(0, 183, 19, 255);
        }
	}
}
