using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//using System.Data;

public class ToggleClusteringStep1 : MonoBehaviour
{
    int btnWhich;
    public GridLayoutGroup chooseGLGroup;
    GameObject glgItem;
    // Use this for initialization
    void Start()
    {
         btnWhich = int.Parse(gameObject.name.Substring(6));
        GetComponentInChildren<Text>().text = EXCELREADER.excelReader.head[btnWhich - 1];
        GetComponent<Toggle>().onValueChanged.AddListener(AddItem);
    }

    void AddItem(bool isOn)
    {
        if (isOn)
        {
            if (!glgItem)
            {
                glgItem = Instantiate(Resources.Load("UGUI/GLGItem", typeof(GameObject))) as GameObject;
                glgItem.transform.parent = chooseGLGroup.transform;
                glgItem.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                glgItem.GetComponentInChildren<Text>().text = GetComponentInChildren<Text>().text;

                //glgItem.transform.Find("Scroll View").GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = ""+ EXCELREADER.excelReader.textScroll[btnWhich-1];
                string[] data = EXCELREADER.excelReader.textScroll[btnWhich - 1].Split("\n"[0]);
                //print(" data.Length" + data.Length);
                //foreach (string str in data) { 
                for (int i=0;i<20;i++) {
                    String str = data[i];
                GameObject text= Instantiate(Resources.Load("UGUI/Text", typeof(GameObject))) as GameObject;
                text.transform.parent= glgItem.transform.Find("Scroll View").GetChild(0).GetChild(0);
                    text.GetComponent<Text>().text = str;
                }
            }
            else
            {
                glgItem.SetActive(true);
            }
        }
        else
        {
            glgItem.SetActive(false);
        }

        float widthChooseGLGroup = chooseGLGroup.gameObject.GetComponent<RectTransform>().sizeDelta.x;
        int count = 0;
        foreach (Transform child in chooseGLGroup.transform)
            if (child.gameObject.activeSelf)
                count++;
        chooseGLGroup.GetComponent<GridLayoutGroup>().cellSize = new Vector2(widthChooseGLGroup / count, chooseGLGroup.GetComponent<GridLayoutGroup>().cellSize.y);

        foreach (Transform child in chooseGLGroup.transform)
            child.transform.Find("Scroll View").GetChild(0).GetChild(0).GetComponent<GridLayoutGroup>().cellSize = new Vector2(widthChooseGLGroup / count, 35);
        if (count >= 3)
        {
            ClusteringSteps.clusteringSteps.lineBtn2.SetActive(true);
        }
    }



    ////public TextAsset binAsset;
    ////public Text guitext;
    ////void Start()
    ////{
    ////    ReadCsvTxt();
    ////}
    //string[] head;
    //string[] textScroll =new string[8];
    //void ReadCsvTxt()
    //{
    //    TextAsset binAsset = Resources.Load("txtList", typeof(TextAsset)) as TextAsset;

    //    //guitext.text = binAsset.text;
    //    string[] data = binAsset.text.Split("\n"[0]);//\r,
    //    int timeNick = 0;
    //    foreach (var dat in data)
    //    {
    //        //a = dat;
    //        Debug.Log(dat);//到此为止，已经把每格的数据单独作为TXT的一行写入了，可以用于其他调用了。 
    //        string[] lineData = dat.Split(',');

    //        timeNick++;
    //        if (timeNick == 1)
    //            head = lineData;
    //        else
    //        {
    //            for(int i = 0; i < 8; i++)
    //            {
    //                textScroll[i]+= "/r/n" + lineData[i];
    //            }
    //            //textScroll[]
    //        }

    //    }

    //    print("dasss" + binAsset.text);
    //}
}
