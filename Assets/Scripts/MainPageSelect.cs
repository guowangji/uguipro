using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPageSelect : MonoBehaviour {
    public GameObject page1, page2, page3;
    // Use this for initialization
    void Start () {
        GetComponent<Button>().onClick.AddListener(Selected);
	}


    private void Selected()
    {
        switch (ToStepNextBtn.threeMenu)
        {
            case 1:
                page1.SetActive(true);
                break;
            case 2:
                page2.SetActive(true);
                break;
            case 3:
                page3.SetActive(true);
                break;

        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
