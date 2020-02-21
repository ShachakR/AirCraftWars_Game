using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public GameObject playerUI;
    public GameObject AbilityTree;
    public GameObject player;
    public Text skillpointTXT;
    public Text CompleteWaveTXT;
    public GameObject GameOverTxt;
    public GameObject WonTxt;
    [HideInInspector]
    // Use this for initialization
    void Start () {
        AbilityTree.SetActive(false);
        playerUI.SetActive(true);
        CompleteWaveTXT.enabled = false;
        Time.timeScale = 1;
        GameOverTxt.SetActive(false);
        WonTxt.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        float n = GameObject.Find("Player").GetComponent<PlayerController>().skillPoints;
        skillpointTXT.text = n.ToString();
        if(GetComponent<Waves>().completed == true)
        {
            CompleteWaveTXT.enabled = true; 
        }
        else
        {
            CompleteWaveTXT.enabled = false;
        }

        if(player.GetComponent<PlayerController>().health <= 0 || player.GetComponent<PlayerController>().EarthHealth.value <= 0)
        {
            GameOverTxt.SetActive(true);
            Debug.Log("GameOver");
        }

        if (GetComponent<Waves>().Won == true)
        {
            CompleteWaveTXT.enabled = false;
            WonTxt.SetActive(true);
            Debug.Log("You Won");
        }
    }

    public void AbilityTreeUI()
    {
        Time.timeScale = 0;
        AbilityTree.SetActive(true);
        playerUI.SetActive(false);
    }

    public void backToGame()
    {
        Time.timeScale = 1;
        AbilityTree.SetActive(false);
        playerUI.SetActive(true);
    }
}
