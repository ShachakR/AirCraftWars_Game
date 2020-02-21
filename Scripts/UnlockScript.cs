using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockScript : MonoBehaviour {
    public float SPRequriment;
    public Button ThisButton;
    public bool unlocked;
    public GameObject previousAbility;
    bool unlockedLast; 
	// Use this for initialization
	void Start () {
        ThisButton.interactable = false;
        unlocked = false;
        unlockedLast = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (previousAbility.GetComponent<UnlockScript>().unlocked == true || previousAbility.name == gameObject.name)
        {
            unlockedLast = true;
        }


        if (GameObject.Find("Player").GetComponent<PlayerController>().skillPoints >= SPRequriment && unlocked == false  && unlockedLast == true|| unlocked == true)
        {
            ThisButton.interactable = true;
        }

        else
        {
            ThisButton.interactable = false;
        }
	}

    public void UnlockSkill()
    {
        if(GameObject.Find("Player").GetComponent<PlayerController>().skillPoints >= SPRequriment)
        {
            unlocked = true;
            GameObject.Find("Player").GetComponent<PlayerController>().skillPoints -= SPRequriment;
        }
    }
}
