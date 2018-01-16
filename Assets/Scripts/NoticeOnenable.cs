using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeOnenable : MonoBehaviour {
    public GameObject textBackgrund;
	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        textBackgrund.SetActive(false);
    }
}
