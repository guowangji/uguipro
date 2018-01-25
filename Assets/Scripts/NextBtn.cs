using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextBtn : MonoBehaviour {
    public GameObject thisPage,nextPage;

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(NextPage);
	}
	

    void NextPage()
    {
        if(thisPage)
        thisPage.SetActive(false);
        if (nextPage)
            nextPage.SetActive(true);
    }


	//// Update is called once per frame
	//void Update () {
		
	//}
}
