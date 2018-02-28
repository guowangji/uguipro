using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class EXCELREADER : MonoBehaviour
{
    public static EXCELREADER excelReader;
    void Start()
    {
        ReadCsvTxt();
        //print(""+ textScroll[0]);
        excelReader = this;

    }

   public string[] head;
    public string[] textScroll =  {"", "", "", "", "", "", "", "" };
    void ReadCsvTxt()
    {
        //把csv改为txt文件
        TextAsset binAsset = Resources.Load("txtList", typeof(TextAsset)) as TextAsset;
        //guitext.text = binAsset.text;
        string[] data = binAsset.text.Split("\n"[0]);//\r,
        int timeNick = 0;
        foreach (var dat in data)
        {
            //Debug.Log(dat);//到此为止，已经把每格的数据单独作为TXT的一行写入了，可以用于其他调用了。 
            string[] lineData = dat.Split(',');
            //print("aa" + lineData[0]);
            timeNick++;
            if (timeNick == 1)
                head = lineData;
            else
            {

                for (int i = 0; i <8; i++)
                {
                    //print("aa" + i);
                    if(textScroll[i].Equals(""))
                        textScroll[i] += lineData[i];
                   textScroll[i] += "\r\n" + lineData[i];//+= "\r\n" +
                }
            }

        }
    }
}
