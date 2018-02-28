using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableObjectScene1 : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //原来的位置
    Vector2 myPivot;
    Vector3 myPos;
    Transform btnTopPanel,parentPanel;
    public static GameObject xSave,ySave,predictionSave;

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
            case "TextX-axis":
                if (xSave)
                    xSave.SetActive(true);
                xSave = gameObject;
                if (ySave != null)
                {
                    switch (ToStepNextBtn.threeMenu)
                    {
                        case 1:
                            ClassificationSteps.classificationSteps.lineBtn2.SetActive(true);
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
                            ClassificationSteps.classificationSteps.lineBtn2.SetActive(true);
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
        transfLast.Find("Button").Find("Text").GetComponent<Text>().text = GetComponentInChildren<Text>().text;
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