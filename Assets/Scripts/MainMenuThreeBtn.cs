using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuThreeBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Toggle>().onValueChanged.AddListener(ThreeChooseOne);//AddListener(ThreeChooseOne);
	}
	

    void ThreeChooseOne(bool isSeclet)
    {
        if (!isSeclet)
            return;
        if(gameObject.name.Equals("Toggle"))
        ToStepNextBtn.threeMenu = 1;
        else if (gameObject.name.Contains("1"))
        {
            ToStepNextBtn.threeMenu = 2;
        }
        else if (gameObject.name.Contains("2"))
            ToStepNextBtn.threeMenu = 3;
    }
}
