using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableObjectScene2 : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //原来的位置
    Vector2 myPivot;
    Vector3 myPos;
    Transform btnTopPanel,parentPanel;
    public static GameObject xSave,ySave,predictionSave, predictionSave1;
    public bool isDimentionalityReduction = true;
    string textLast;
    Transform transfLast;

    void Start()
    {
        btnTopPanel = transform.parent.parent.Find("btnTopPanel");
        parentPanel = transform.parent;
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().sizeDelta;
    }

    //Drag事件，设置目标的位置为鼠标的位置
    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().pivot.Set(0, 0);
        transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        myPivot = transform.GetComponent<RectTransform>().pivot;
        myPos = transform.GetComponent<RectTransform>().position;

        transform.parent = btnTopPanel;
        //缩小
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        switch (textLast)
        {
            case "TextPrediction":
                if (predictionSave)
                    predictionSave.SetActive(true);
                predictionSave = gameObject;
               if (predictionSave1)
                ClusteringSteps.clusteringSteps.lineBtn3.SetActive(true);
                transfLast.Find("Button").Find("Text").GetComponent<Text>().text = GetComponentInChildren<Text>().text;
                transfLast.Find("Button").Find("Text").GetComponent<Text>().color = new Color(0, 0, 0);
                break;
            case "TextPrediction1":
                if (predictionSave1)
                    predictionSave1.SetActive(true);
                predictionSave1 = gameObject;
                if (predictionSave)
                    ClusteringSteps.clusteringSteps.lineBtn3.SetActive(true);

                if (GetComponentInChildren<Text>().text.Equals("K-means"))
                {
                    transfLast.Find("Button").Find("Text").gameObject.SetActive(false);
                    transfLast.Find("Button").Find("DropText").gameObject.SetActive(true);
                }
                else
                {
                    transfLast.Find("Button").Find("Text").gameObject.SetActive(true);
                    transfLast.Find("Button").Find("DropText").gameObject.SetActive(false);
                    transfLast.Find("Button").Find("Text").GetComponent<Text>().text = GetComponentInChildren<Text>().text;
                    transfLast.Find("Button").Find("Text").GetComponent<Text>().color = new Color(0, 0, 0);
                }
                break;
            default:
                PointerUp();
                return;
        }
        PointerUp();
        
        gameObject.SetActive(false);
    }

    void PointerUp()
    {
        //正常大小
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.parent = parentPanel;
        transform.GetComponent<RectTransform>().pivot.Set(myPivot.x, myPivot.y);
        transform.position = myPos;
        textLast = "";
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.name.Equals("TextPrediction")&& isDimentionalityReduction )|| (collider.name.Equals("TextPrediction1")&&!isDimentionalityReduction))
        {
            textLast = collider.name;
            transfLast = collider.transform;
        }
       
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name.Equals(textLast))
        {
            textLast = "";
        }



        //if (collider.name.Equals("TextX-axis")|| collider.name.Equals("TextY-axis"))
        //{
        //    if (textLast.Equals(GetComponentInChildren<Text>().text))
        //    {

            //        gameObject.SetActive(false);
            //    }
            //}
    }
    
}