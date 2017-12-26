using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepButton : MonoBehaviour {
    Sequence mySequence;
    static Vector2 sizeStepBtn, sizeStepBtnLong;
    static float posStepBtn, posStepBtnLong;
    // Use this for initialization
    void Start () {
        //mySequence = DOTween.Sequence();
        switch (gameObject.name)
        {
            case "Button (1)":
                GetComponent<Button>().onClick.AddListener(ClickBtn1);
                sizeStepBtnLong = GetComponent<Image>().rectTransform.sizeDelta;
                posStepBtnLong=GetComponent<Image>().rectTransform.anchoredPosition.x;
                //print("widthStepBtnLong" + widthStepBtnLong + "ClassificationSteps.classificationSteps.btn1.GetComponent<Image>().rectTransform.position.x" + GetComponent<Image>().rectTransform.anchoredPosition.x);
                break;
            case "Button (2)":
                GetComponent<Button>().onClick.AddListener(ClickBtn2);
                sizeStepBtn=GetComponent<Image>().rectTransform.sizeDelta;
                posStepBtn = GetComponent<Image>().rectTransform.anchoredPosition.x;
                //gameObject.SetActive(false);
                break;
            case "Button (3)":
                GetComponent<Button>().onClick.AddListener(ClickBtn3);
                //gameObject.SetActive(false);
                break;

        }
    }



    public  void ClickBtn1()
    {
        switch(ToStepNextBtn.threeMenu)
        {
            case 1:
            ClassificationSteps.classificationSteps.step1.SetActive(true);
            ClassificationSteps.classificationSteps.step2.SetActive(false);
            ClassificationSteps.classificationSteps.step3.SetActive(false);
            ClassificationSteps.classificationSteps.lineBtn1.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtnLong;
            ClassificationSteps.classificationSteps.lineBtn2.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            ClassificationSteps.classificationSteps.lineBtn3.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            float y = ClassificationSteps.classificationSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y1 = ClassificationSteps.classificationSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y2 = ClassificationSteps.classificationSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition.y;
            ClassificationSteps.classificationSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtnLong, y);
            ClassificationSteps.classificationSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y1);
            ClassificationSteps.classificationSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y2);
                break;
            case 2:
            RegressionSteps.regressionSteps.step1.SetActive(true);
            RegressionSteps.regressionSteps.step2.SetActive(false);
            RegressionSteps.regressionSteps.step3.SetActive(false);
            RegressionSteps.regressionSteps.lineBtn1.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtnLong;
            RegressionSteps.regressionSteps.lineBtn2.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            RegressionSteps.regressionSteps.lineBtn3.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            float y3 = RegressionSteps.regressionSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y4 = RegressionSteps.regressionSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y5 = RegressionSteps.regressionSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition.y;
            RegressionSteps.regressionSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtnLong, y3);
            RegressionSteps.regressionSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y4);
            RegressionSteps.regressionSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y5);
                break;
            case 3:
                ClusteringSteps.clusteringSteps.step1.SetActive(true);
                ClusteringSteps.clusteringSteps.step2.SetActive(false);
                ClusteringSteps.clusteringSteps.step3.SetActive(false);
                ClusteringSteps.clusteringSteps.lineBtn1.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtnLong;
                ClusteringSteps.clusteringSteps.lineBtn2.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
                ClusteringSteps.clusteringSteps.lineBtn3.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
                float y6 = ClusteringSteps.clusteringSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition.y;
                float y7 = ClusteringSteps.clusteringSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition.y;
                float y8 = ClusteringSteps.clusteringSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition.y;
                ClusteringSteps.clusteringSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtnLong, y6);
                ClusteringSteps.clusteringSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y7);
                ClusteringSteps.clusteringSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y8);
                break;
        }
        }

    void ClickBtn2()
    {
        switch (ToStepNextBtn.threeMenu)
        {
            case 1:
                ClassificationSteps.classificationSteps.step1.SetActive(false);
            ClassificationSteps.classificationSteps.step2.SetActive(true);
            ClassificationSteps.classificationSteps.step3.SetActive(false);
            ClassificationSteps.classificationSteps.lineBtn1.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            ClassificationSteps.classificationSteps.lineBtn2.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtnLong;
            ClassificationSteps.classificationSteps.lineBtn3.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            float y = ClassificationSteps.classificationSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y1 = ClassificationSteps.classificationSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y2 = ClassificationSteps.classificationSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition.y;
            ClassificationSteps.classificationSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y);
            ClassificationSteps.classificationSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtnLong, y1);
            ClassificationSteps.classificationSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y2);
                break;
            case 2:
                RegressionSteps.regressionSteps.step1.SetActive(false);
            RegressionSteps.regressionSteps.step2.SetActive(true);
            RegressionSteps.regressionSteps.step3.SetActive(false);
            RegressionSteps.regressionSteps.lineBtn1.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            RegressionSteps.regressionSteps.lineBtn2.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtnLong;
            RegressionSteps.regressionSteps.lineBtn3.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            float y3 = RegressionSteps.regressionSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y4 = RegressionSteps.regressionSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y5 = RegressionSteps.regressionSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition.y;
            RegressionSteps.regressionSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y3);
            RegressionSteps.regressionSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtnLong, y4);
            RegressionSteps.regressionSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y5);
                break;
            case 3:
                ClusteringSteps.clusteringSteps.step1.SetActive(false);
                ClusteringSteps.clusteringSteps.step2.SetActive(true);
                ClusteringSteps.clusteringSteps.step3.SetActive(false);
                ClusteringSteps.clusteringSteps.lineBtn1.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
                ClusteringSteps.clusteringSteps.lineBtn2.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtnLong;
                ClusteringSteps.clusteringSteps.lineBtn3.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
                float y6 = ClusteringSteps.clusteringSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition.y;
                float y7 = ClusteringSteps.clusteringSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition.y;
                float y8 = ClusteringSteps.clusteringSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition.y;
               ClusteringSteps.clusteringSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y6);
               ClusteringSteps.clusteringSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtnLong, y7);
                ClusteringSteps.clusteringSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y8);
                break;
        }


        //mySequence.Kill(false);
        //btn1缩回
        //mySequence.Append(ClassificationSteps.classificationSteps.btn1.GetComponent<Image>().rectTransform.DOSizeDelta(new Vector2(193,31), 2));
        //mySequence.Insert(0, ClassificationSteps.classificationSteps.btn1.GetComponent<Image>().rectTransform.DOAnchorPosX(ClassificationSteps.classificationSteps.btn1.GetComponent<Image>().rectTransform.anchoredPosition.x - ((widthStepBtnLong - widthStepBtn) / 2), 2f));
        //btn2伸长
        //ClassificationSteps.classificationSteps.btn2.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(widthStepBtn, 31);
        //mySequence.Append(ClassificationSteps.classificationSteps.btn2.GetComponent<Image>().rectTransform.DOSizeDelta(new Vector2(widthStepBtnLong, 31), 2));
        //mySequence.Insert(0, ClassificationSteps.classificationSteps.btn2.GetComponent<Image>().rectTransform.DOAnchorPosX(ClassificationSteps.classificationSteps.btn2.GetComponent<Image>().rectTransform.anchoredPosition.x +((widthStepBtnLong - widthStepBtn) / 2), 2f));

    }

    void ClickBtn3()
    {
        switch (ToStepNextBtn.threeMenu)
        {
            case 1:
                ClassificationSteps.classificationSteps.step1.SetActive(false);
            ClassificationSteps.classificationSteps.step2.SetActive(false);
            ClassificationSteps.classificationSteps.step3.SetActive(true);
            ClassificationSteps.classificationSteps.lineBtn1.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            ClassificationSteps.classificationSteps.lineBtn2.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            ClassificationSteps.classificationSteps.lineBtn3.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtnLong;
            float y = ClassificationSteps.classificationSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y1 = ClassificationSteps.classificationSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y2 = ClassificationSteps.classificationSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition.y;
            ClassificationSteps.classificationSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y);
            ClassificationSteps.classificationSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y1);
            ClassificationSteps.classificationSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtnLong, y2);
                break;
            case 2:
                RegressionSteps.regressionSteps.step1.SetActive(false);
            RegressionSteps.regressionSteps.step2.SetActive(false);
            RegressionSteps.regressionSteps.step3.SetActive(true);
            RegressionSteps.regressionSteps.lineBtn1.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            RegressionSteps.regressionSteps.lineBtn2.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
            RegressionSteps.regressionSteps.lineBtn3.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtnLong;
            float y3 = RegressionSteps.regressionSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y4 = RegressionSteps.regressionSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition.y;
            float y5 = RegressionSteps.regressionSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition.y;
            RegressionSteps.regressionSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y3);
            RegressionSteps.regressionSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y4);
            RegressionSteps.regressionSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtnLong, y5);
                break;
            case 3:
                ClusteringSteps.clusteringSteps.step1.SetActive(false);
                ClusteringSteps.clusteringSteps.step2.SetActive(false);
                ClusteringSteps.clusteringSteps.step3.SetActive(true);
                ClusteringSteps.clusteringSteps.lineBtn1.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
                ClusteringSteps.clusteringSteps.lineBtn2.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtn;
                ClusteringSteps.clusteringSteps.lineBtn3.GetComponent<Image>().rectTransform.sizeDelta = sizeStepBtnLong;
                float y6 = ClusteringSteps.clusteringSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition.y;
                float y7 = ClusteringSteps.clusteringSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition.y;
                float y8 = ClusteringSteps.clusteringSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition.y;
                ClusteringSteps.clusteringSteps.lineBtn1.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y6);
                ClusteringSteps.clusteringSteps.lineBtn2.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtn, y7);
                ClusteringSteps.clusteringSteps.lineBtn3.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(posStepBtnLong, y8);
                break;
        }
        }

}
