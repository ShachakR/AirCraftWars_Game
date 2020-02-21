using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TextAnimation : MonoBehaviour {
    public float delay = 0.1f;
    private string currentText = "";
    public Text text; 
    bool active;
    [Multiline]
    public string fulltext;
    // Use this for initialization
    void Start () {
        active = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (text.enabled == true)
        {
            if (!active)
            {
                StartCoroutine(ShowText());
                active = true;
            }
        }
        if(text.enabled == false)
        {
            active = false;
        }
	}

    IEnumerator ShowText()
    {
        for(int i = 0; i < fulltext.Length; i++)
        {
            currentText = fulltext.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }
}
