using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MouseHover : MonoBehaviour {

    [Multiline]
    public string myString;
    public Text myText;
	// Use this for initialization
	void Start () {
        myText.GetComponent<Text>();
        myText.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
	}

   public void InfoEnter()
    {
            myText.text = myString;
        myText.color = Color.white;
            Debug.Log("TEXT");
    }

    public void InfoExit()
    {
        myText.text = myString;
        myText.color = Color.clear;
    }
}
