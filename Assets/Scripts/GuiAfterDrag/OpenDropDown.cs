using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenDropDown : MonoBehaviour, IPointerUpHandler
{
    public int indexChoose=-1;
    // Use this for initialization
    void Start () {
        GetComponent<Dropdown>().onValueChanged.AddListener(ClickDropdown);//Dropdown List
    }

    bool pointerUp = false;
    public void OnPointerUp(PointerEventData eventData)
    {
        pointerUp = true;
    }

    void Update()
    {
        if (pointerUp&&transform.Find("Dropdown List") && transform.Find("Dropdown List").gameObject.GetComponent<RectTransform>().sizeDelta.y!=106)
        {
            pointerUp = false;
            Vector2 size = transform.Find("Dropdown List").gameObject.GetComponent<RectTransform>().sizeDelta;
            size.y = 176;
            transform.Find("Dropdown List").gameObject.GetComponent<RectTransform>().sizeDelta = size;

            foreach (Transform tra in transform.Find("Dropdown List").Find("Viewport").Find("Content"))
                tra.GetComponentInChildren<Text>().color = new Color(1, 1, 1);
            transform.Find("Dropdown List").Find("Viewport").Find("Content").GetChild(indexChoose + 1).GetComponentInChildren<Text>().color = new Color(23/255f,234 / 255f,217 / 255f);

        }
    }



    private void ClickDropdown(int index)
    {
        //Debug.Log("sda"+ index);//23.234.217
        indexChoose = index;
        print(index+"asssaa" + transform.Find("Dropdown List").Find("Viewport").Find("Content").GetChild(index+1).name);

       

    }

}
