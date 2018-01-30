using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeuralNetwork : MonoBehaviour {
    public static NeuralNetwork neuralNetwork;
    public GridLayoutGroup DrawPanel;
    public Button addBtn, subtract;
    Text textNum;
    public static Dictionary<int, CellPosList> cellListDic = new Dictionary<int, CellPosList>();
    // Use this for initialization
    void Start () {
        neuralNetwork = this;
        addBtn.onClick.AddListener(AddGridChild);
        subtract.onClick.AddListener(SubtractCell);
        cellListDic.Add(0, DrawPanel.transform.Find("GridChild1").GetComponent<CellPosList>());
        cellListDic.Add(1, DrawPanel.transform.Find("GridChild2").GetComponent<CellPosList>());
        cellListDic.Add(2, DrawPanel.transform.Find("GridChild3").GetComponent<CellPosList>());
        textNum = addBtn.transform.parent.Find("Text").GetComponent<Text>();
    }

    void AddGridChild()
    {
        if (cellListDic.Count < 6)
        {
            Transform GridChild = (Instantiate(Resources.Load("UGUI/GridChild", typeof(GameObject))) as GameObject).transform;
        GridChild.SetParent(DrawPanel.transform);
            GridChild.name = "GridChild" + (cellListDic.Count+1);
        GridChild.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
        GridChild.localScale = new Vector3(1, 1, 1);
            cellListDic.Add(cellListDic.Count, GridChild.GetComponent<CellPosList>());
            textNum.text = cellListDic.Count + "";
        }
    }
    void SubtractCell()
    {
        if (cellListDic.Count > 3)
        {
            Destroy(cellListDic[cellListDic.Count - 1].gameObject);
            cellListDic.Remove(cellListDic.Count - 1);
            textNum.text = cellListDic.Count + "";
        }

    }
}
