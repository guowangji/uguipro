using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
    public Vector3 cellPos;
    //public float x, y, z;
	// Use this for initialization
	void Start () {
        //cellPos=new Vector3(transform.Find("cell").position.x, transform.Find("cell").position.y, transform.Find("cell").position.z - 10);
        cellPos = transform.Find("cell").position;
        //x = cellPos.x;
        //y = cellPos.y;
        //z = cellPos.z;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
