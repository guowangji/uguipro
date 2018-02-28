using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(RestartBtn);
	}
	
	void RestartBtn()
    {
        SceneManager.LoadScene("01");
    }
}
