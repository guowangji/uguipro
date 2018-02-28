using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableObjectPrediction2a : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IEndDragHandler
{
    //原来的位置
    Vector2 myPivot;
    Vector3 myPos;
    Transform btnTopPanel,parentPanel;
    bool notDragOut = true;

    void Start()
    {
        btnTopPanel = transform.parent.parent.parent.Find("btnTopPanel");
        parentPanel = transform.parent;
        GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().sizeDelta;

        myPivot = transform.GetComponent<RectTransform>().pivot;
        myPos = transform.GetComponent<RectTransform>().position;
    }

    //Drag事件，设置目标的位置为鼠标的位置
    public void OnDrag(PointerEventData eventData)
    {
        if (transform.localScale.x==1f)
        {
            eventData.clickCount++;
            OnPointerDown(eventData);
        }

        GetComponent<RectTransform>().pivot.Set(0, 0);
        transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //myPivot = transform.GetComponent<RectTransform>().pivot;
        //myPos = transform.GetComponent<RectTransform>().position;

        transform.parent = btnTopPanel;
        //缩小
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }

    //注：当按到Dropdown控件时会监听不到该方法
    public void OnPointerUp(PointerEventData eventData)
    {
        //print("2aOnPointerUp");
        DoOnPointerUp();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("结束拖拽");
        DoOnPointerUp();
    }

    public void DoOnPointerUp()
    {
        if (!notDragOut)
        {
            ClusteringSteps.clusteringSteps.lineBtn3.SetActive(false);
            transform.Find("Text").gameObject.SetActive(true);
            transform.Find("DropText").gameObject.SetActive(false);
            GetComponentInChildren<Text>().text = "Clustering";
            GetComponentInChildren<Text>().color = new Color(143/255f, 143 / 255f, 143 / 255f, 255 / 255f);
            if (DraggableObjectScene2.predictionSave1)
                DraggableObjectScene2.predictionSave1.SetActive(true);
            DraggableObjectScene2.predictionSave1 = null;
        }

        PointerUp();
    }


    void PointerUp()
    {
        //正常大小
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.parent = parentPanel;
        transform.GetComponent<RectTransform>().pivot.Set(myPivot.x, myPivot.y);
        transform.position = myPos;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Equals("TextPrediction1"))
        {
            notDragOut = true;
        }

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name.Equals("TextPrediction1"))
        {
            notDragOut = false;
        }

    }
    
}