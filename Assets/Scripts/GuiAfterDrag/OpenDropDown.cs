using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenDropDown : MonoBehaviour, IPointerUpHandler
{

	// Use this for initialization
	void Start () {
        //GetComponent<Dropdown>().op
        GetComponent<Dropdown>().onValueChanged.AddListener(ClickDropdown);//Dropdown List
    }

    bool pointerUp = false;
    public void OnPointerUp(PointerEventData eventData)
    {
        pointerUp = true;
    }

    void Update()
    {
        if (pointerUp&&transform.Find("Dropdown List") && transform.Find("Dropdown List").gameObject.GetComponent<RectTransform>().sizeDelta.y!=110)
        {
            pointerUp = false;
            Debug.Log("sda" + transform.Find("Dropdown List").gameObject.GetComponent<RectTransform>().sizeDelta.y);
            Vector2 size = transform.Find("Dropdown List").gameObject.GetComponent<RectTransform>().sizeDelta;
            size.y = 110;
            transform.Find("Dropdown List").gameObject.GetComponent<RectTransform>().sizeDelta = size;
        }
    }



    private void ClickDropdown(int index)
    {
        Debug.Log("sda"+ index);
    }

}
