using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellPosList : MonoBehaviour {

     public Dictionary<int, Cell> cellDic = new Dictionary<int, Cell>();
    public Button Add, Subtract;
    int numList;
    // Use this for initialization
    void Start () {
        Add.onClick.AddListener(AddCell);
        Subtract.onClick.AddListener(SubtractCell);
        cellDic.Add(0,transform.Find("CellPanel1").GetComponent<Cell>());
        cellDic.Add(1, transform.Find("CellPanel2").GetComponent<Cell>());
        numList = int.Parse(gameObject.name.Substring(9, 1));
        //    NeuralNetwork.cellListDic[1].
        StartCoroutine(waitme());
    }

    IEnumerator waitme()
    {
        yield return new WaitForSeconds(0.01f);
        if (gameObject.name.Equals("GridChild1"))
            yield break;
        
        if (NeuralNetwork.cellListDic[numList - 2].cellDic.Count < 2)
        {
            print("lost Dic");
            StartCoroutine(waitme());
        }
            

        if (numList > 1)
        {
            //NeuralNetwork.cellListDic[0].cellDic[0]
            foreach (var item1 in NeuralNetwork.cellListDic[numList-2].cellDic)
            {

                foreach (var item2 in cellDic)
                {
                    Transform cellLine = (Instantiate(Resources.Load("UGUI/CellLine", typeof(GameObject))) as GameObject).transform;
                    cellLine.SetParent(item2.Value.transform);

                    cellLine.gameObject.GetComponent<CellLine>().start = item1.Value.transform.Find("cell").gameObject;
                    cellLine.gameObject.GetComponent<CellLine>().end = item2.Value.transform.Find("cell").gameObject;
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

            if(NeuralNetwork.cellListDic.Count> numList)
            foreach (var item3 in NeuralNetwork.cellListDic[numList].cellDic)
            {
                Transform cellLine = (Instantiate(Resources.Load("UGUI/CellLine", typeof(GameObject))) as GameObject).transform;
                cellLine.SetParent(Cell);
                cellLine.gameObject.GetComponent<CellLine>().start = item3.Value.transform.Find("cell").gameObject;
                cellLine.gameObject.GetComponent<CellLine>().end = Cell.Find("cell").gameObject;
            }
            if (numList > 1)
            {
                foreach (var item4 in NeuralNetwork.cellListDic[numList - 2].cellDic)
                {
                    Transform cellLine = (Instantiate(Resources.Load("UGUI/CellLine", typeof(GameObject))) as GameObject).transform;
                    cellLine.SetParent(Cell);
                    cellLine.gameObject.GetComponent<CellLine>().start = item4.Value.transform.Find("cell").gameObject;
                    cellLine.gameObject.GetComponent<CellLine>().end = Cell.Find("cell").gameObject;
                }
            }

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
