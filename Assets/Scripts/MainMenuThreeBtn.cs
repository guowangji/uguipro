using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuThreeBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(ThreeChooseOne);
	}
	

    void ThreeChooseOne()
    {
        if(gameObject.name.Equals("Button"))
        ToStepNextBtn.threeMenu = 1;
        else if (gameObject.name.Contains("1"))
        {
            ToStepNextBtn.threeMenu = 2;
        }
        else if (gameObject.name.Contains("2"))
            ToStepNextBtn.threeMenu = 3;
    }
}
