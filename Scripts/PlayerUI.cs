using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {
    public GameObject gameManger;
    public GameObject player;
    public GameObject abilityTree;
    public Button AbilityOne;
    public Button AbilityTwo;
    public Button AbilityThree;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        AbilityOne.image.sprite = abilityTree.GetComponent<AbilityController>().abilityOne.image.sprite;
        AbilityTwo.image.sprite = abilityTree.GetComponent<AbilityController>().abilityTwo.image.sprite;
        AbilityThree.image.sprite = abilityTree.GetComponent<AbilityController>().abilityThree.image.sprite;
        }
	}
