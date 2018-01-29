using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenDropDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GetComponent<Dropdown>().op
        GetComponent<Dropdown>().onValueChanged.AddListener(ClickDropdown);//Dropdown List
    }
    void Dropdown1(PointerEventData pointerEventsData)
    {


    }

    private void ClickDropdown(int index)
    {
        Debug.Log("sda"+ index);
    }

    void Dropdown(int isTrue)
    {


    }
	// Update is called once per frame
	void Update () {
		
	}
}
