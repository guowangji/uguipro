﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellPosList : MonoBehaviour {

     public Dictionary<int, Cell> cellDic = new Dictionary<int, Cell>();
    public Button Add, Subtract;
	// Use this for initialization
	void Start () {
        Add.onClick.AddListener(AddCell);
        Subtract.onClick.AddListener(SubtractCell);
        cellDic.Add(0,transform.Find("CellPanel1").GetComponent<Cell>());
        cellDic.Add(1, transform.Find("CellPanel2").GetComponent<Cell>());
        //if (gameObject.name.Equals("GridChild1"))
        //    NeuralNetwork.cellListDic[1].
            StartCoroutine(waitme());
    }


    IEnumerator waitme()
    {
        yield return new WaitForSeconds(0.5f);
        if (gameObject.name.Equals("GridChild2"))//|| gameObject.name.Equals("GridChild (2)")
        {
            //NeuralNetwork.cellListDic[0].cellDic[0]
            foreach (var item1 in NeuralNetwork.cellListDic[0].cellDic)
            {
                
                foreach (var item2 in cellDic)
                {
                    Transform cellLine = (Instantiate(Resources.Load("UGUI/CellLine", typeof(GameObject))) as GameObject).transform;
                    cellLine.SetParent(item2.Value.transform);
                    LineRenderer line= cellLine.GetComponent<LineRenderer>();
                        line.positionCount = 2;
                    //设置线的宽度
                    line.startWidth = 0.1f;
                    line.endWidth = 0.1f;
                    line.SetPosition(0, item1.Value.cellPos);
                    line.SetPosition(1, item2.Value.cellPos);

                    //print("pos" + item2.Value.cellPos);
                }
            }
        }
    }

    // Update is called once per frame
    void AddCell () {
        if (cellDic.Count < 8) { 
        Transform Cell = (Instantiate(Resources.Load("UGUI/CellPanel", typeof(GameObject))) as GameObject).transform;
        Cell.SetParent(transform);
        Cell.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0,0);
        Cell.localScale = new Vector3(1, 1, 1);
            cellDic.Add(cellDic.Count, Cell.GetComponent<Cell>());
    }
    }

    void SubtractCell()
    {
        if (cellDic.Count > 2)
        {
            Destroy(cellDic[cellDic.Count - 1].gameObject);
            cellDic.Remove(cellDic.Count - 1);
        }

    }
}
