using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour{
    public Button abilityOne;
    public Button abilityTwo;
    public Button abilityThree;
    string temp;
    string selectTemp;
    [HideInInspector]
    Button[] slots = new Button[3];
    // Use this for initialization
    void Start()
    {
        //disableAblitites();
        slots[0] = abilityOne;
        slots[1] = abilityTwo;
        slots[2] = abilityThree;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void getBtn(Button btn)//AbilitySPOT : Non-Selected
    {
        temp = btn.name;
    }

    public void setAbility(Button select)//SelectedAbilitySPOT
    {
        selectTemp = select.name;
        if(temp != null)
        {
            GameObject.Find(selectTemp).GetComponent<Image>().sprite = GameObject.Find(temp).GetComponent<Image>().sprite;
        }
    }
}
