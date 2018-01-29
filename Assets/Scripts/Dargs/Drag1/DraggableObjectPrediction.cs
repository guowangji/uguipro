using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableObjectPrediction : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //原来的位置
    Vector2 myPivot;
    Vector3 myPos;
    Transform btnTopPanel,parentPanel;
    bool notDragOut = true;

    Vector2 offset = new Vector3();    //用来得到鼠标和图片的差值

    void Start()
    {
        btnTopPanel = transform.parent.parent.Find("btnTopPanel");
        parentPanel = transform.parent;
        GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().sizeDelta;
    }

    //Drag事件，设置目标的位置为鼠标的位置
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mouseDrag = eventData.position;   //当鼠标拖动时的屏幕坐标
        Vector2 uguiPos = new Vector2();   //用来接收转换后的拖动坐标
        //和上面类似
        bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(ClassificationSteps.classificationSteps.GetComponent<RectTransform>(), mouseDrag, eventData.enterEventCamera, out uguiPos);
        if (isRect)
        {
            //设置图片的ugui坐标与鼠标的ugui坐标保持不变
            transform.GetComponent<RectTransform>().anchoredPosition =  uguiPos;
            //transform.GetComponent<RectTransform>().anchoredPosition = offset + uguiPos;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<BoxCollider2D>().size = new Vector2(150, 40);

        Vector2 mouseDown = eventData.position;    //记录鼠标按下时的屏幕坐标
        Vector2 mouseUguiPos = new Vector2();   //定义一个接收返回的ugui坐标
        bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(ClassificationSteps.classificationSteps.GetComponent<RectTransform>(), mouseDown, eventData.enterEventCamera, out mouseUguiPos);
        if (isRect)   //如果在
        {
            //计算图片中心和鼠标点的差值
            offset = transform.GetComponent<RectTransform>().anchoredPosition - mouseUguiPos;
        }
        myPivot = transform.GetComponent<RectTransform>().pivot;
        myPos = transform.GetComponent<RectTransform>().position;

        transform.parent = btnTopPanel;
        //缩小
        transform.localScale = new Vector3(0.7f, 0.7f, 1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!notDragOut)
        {
            ClassificationSteps.classificationSteps.lineBtn3.GetComponent<Toggle>().interactable=false;
           GetComponentInChildren<Text>().text = "";
            if(DraggableObjectScene.predictionSave)
            DraggableObjectScene.predictionSave.SetActive(true);
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

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    Debug.Log("-------开始碰撞------------");
    //    Debug.Log(coll.gameObject.name);
    //}
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("开始接触");
        //Debug.Log(collider.name);
        //collider.transform.Find("Button").Find("Text").GetComponent<Text>().text = GetComponentInChildren<Text>().text;
        //gameObject.SetActive(false);
        if (collider.name.Equals("TextPrediction"))
        {
            notDragOut = true;
        }

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name.Equals("TextPrediction"))
        {
            notDragOut = false;
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