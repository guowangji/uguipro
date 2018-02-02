using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableObjectScene : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //原来的位置
    Vector2 myPivot;
    Vector3 myPos;
    Transform btnTopPanel,parentPanel;
    Sprite saveSprite;
    public static GameObject xSave,ySave,predictionSave;
    string textLast;
    Transform transfLast;

    Vector2 offset = new Vector3();    //用来得到鼠标和图片的差值

    void Start()
    {
        if(transform.parent.parent.name.Equals("noticeTopPlane"))
        btnTopPanel = ClassificationSteps.classificationSteps.step1.transform.Find("btnTopPanel");
        else
        btnTopPanel = transform.parent.parent.Find("btnTopPanel");
        parentPanel = transform.parent;
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().sizeDelta;
    }

    //Drag事件，设置目标的位置为鼠标的位置
    public void OnDrag(PointerEventData eventData)
    {
        ////屏蔽右键
        //if (eventData.currentInputModule.input.GetMouseButtonDown(1))
        //{
        //    return;
        //}
        Vector2 mouseDrag = eventData.position;   //当鼠标拖动时的屏幕坐标
        Vector2 uguiPos = new Vector2();   //用来接收转换后的拖动坐标
        //和上面类似
        bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(ClassificationSteps.classificationSteps.GetComponent<RectTransform>(), mouseDrag, eventData.enterEventCamera, out uguiPos);
        if (isRect)
        {
            //设置图片的ugui坐标与鼠标的ugui坐标保持不变
            transform.GetComponent<RectTransform>().anchoredPosition = offset + uguiPos;
        }
    }


    int rightOrLeftMouse = 0;
    public void OnPointerDown(PointerEventData eventData)
    {
        //屏蔽左右键一起点击
        if(rightOrLeftMouse != 0) { rightOrLeftMouse++; 
        return;
        }
        if (eventData.currentInputModule.input.GetMouseButtonDown(1)||eventData.currentInputModule.input.GetMouseButtonDown(0))
        {
            rightOrLeftMouse ++;
        }

        Vector2 mouseDown = eventData.position;    //记录鼠标按下时的屏幕坐标
        Vector2 mouseUguiPos = new Vector2();   //定义一个接收返回的ugui坐标
        //RectTransformUtility.ScreenPointToLocalPointInRectangle()：把屏幕坐标转化成ugui坐标
        //canvas：坐标要转换到哪一个物体上，这里img父类是Canvas，我们就用Canvas
        //eventData.enterEventCamera：这个事件是由哪个摄像机执行的
        //out mouseUguiPos：返回转换后的ugui坐标
        //isRect：方法返回一个bool值，判断鼠标按下的点是否在要转换的物体上
        bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(ClassificationSteps.classificationSteps.GetComponent<RectTransform>(), mouseDown, eventData.enterEventCamera, out mouseUguiPos);
        if (isRect)   //如果在
        {
            //计算图片中心和鼠标点的差值
            offset = transform.GetComponent<RectTransform>().anchoredPosition - mouseUguiPos;
        }

        saveSprite = GetComponent<Image>().sprite;
        GetComponent<Image>().sprite = null;
        GetComponentInChildren<Text>().color = Color.black;
        myPivot = transform.GetComponent<RectTransform>().pivot;
        myPos = transform.GetComponent<RectTransform>().position;
        transform.SetParent(btnTopPanel);
        //缩小
        transform.localScale = new Vector3(0.7f, 0.7f, 1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rightOrLeftMouse --;
        switch (textLast)
        {
            case "TextX-axis":
                if (xSave)
                    xSave.SetActive(true);
                xSave = gameObject;
                if (ySave != null)
                {
                    switch (ToStepNextBtn.threeMenu)
                    {
                        case 1:
                            ClassificationSteps.classificationSteps.lineBtn2.GetComponent<Toggle>().interactable = true;
                            break;
                        case 2:
                            RegressionSteps.regressionSteps.lineBtn2.SetActive(true);
                            break;
                        case 3:
                            break;
                    }
                   
                }
                break;
            case "TextY-axis":
                if (ySave)
                    ySave.SetActive(true);
                ySave = gameObject;
                if (xSave!=null)
                {
                    switch (ToStepNextBtn.threeMenu)
                    {
                        case 1:
                            ClassificationSteps.classificationSteps.lineBtn2.GetComponent<Toggle>().interactable = true;
                            break;
                        case 2:
                            RegressionSteps.regressionSteps.lineBtn2.SetActive(true);
                            break;
                        case 3:
                            break;
                    }
                }
                break;
            case "TextPrediction":
                if (predictionSave)
                    predictionSave.SetActive(true);
                predictionSave = gameObject;
                if(ToStepNextBtn.threeMenu==1)
                ClassificationSteps.classificationSteps.lineBtn3.GetComponent<Toggle>().interactable = true;
                else if (ToStepNextBtn.threeMenu == 2)
                RegressionSteps.regressionSteps.lineBtn3.SetActive(true);
        break;
            default:
                PointerUp();
                return;
        }
        PointerUp();
        //print("dsaaass"+ GetComponentInChildren<Text>().text);
        transfLast.Find("Button").Find("Text").GetComponent<Text>().text = GetComponentInChildren<Text>().text;
        transfLast.Find("Button").GetComponent<Image>().color=new Color(255/255,1,1,1);

        if (GetComponentInChildren<Text>().text.Equals("Neural Network")) {
            foreach (Transform child in ClassificationSteps.classificationSteps.step2.transform.Find("DrawPanel"))
            {
                child.gameObject.SetActive(false);
            }
            ClassificationSteps.classificationSteps.step2.transform.Find("DrawPanel").Find("NeuralNetwork").gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
    }

    void PointerUp()
    {
        GetComponent<Image>().sprite = saveSprite;
        GetComponentInChildren<Text>().color = Color.white;
        //正常大小
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.parent = parentPanel;
        transform.GetComponent<RectTransform>().pivot.Set(myPivot.x, myPivot.y);
        transform.position = myPos;
        textLast = "";
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
        if (collider.name.Equals("TextX-axis")) {
            //if (xSave)
            //    xSave.SetActive(true);
            // xSave = gameObject;
            //PointerUp();
        }
        else if (collider.name.Equals("TextY-axis")) {
            //if (ySave)
            //    ySave.SetActive(true);
            //ySave = gameObject;
            //PointerUp();
        }
        else if (collider.name.Equals("TextPrediction"))
        {
            //if (predictionSave)
            //    predictionSave.SetActive(true);
            //predictionSave = gameObject;
            //PointerUp();
        }
        else return;
        //textLast = collider.transform.Find("Button").Find("Text").GetComponent<Text>().text;
        textLast = collider.name;
        transfLast = collider.transform;
        //collider.transform.Find("Button").Find("Text").GetComponent<Text>().text = GetComponentInChildren<Text>().text;
        //gameObject.SetActive(false);
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