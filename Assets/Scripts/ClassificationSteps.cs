using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassificationSteps : MonoBehaviour
{
    public GameObject step1, step2, step3;//页面
    public GameObject lineBtn1, lineBtn2, lineBtn3;//按钮
    public GameObject notice, noticeBtns, noticeAxisArea;
    public GameObject canvas;
    public static ClassificationSteps classificationSteps;

    // Use this for initialization
    void Start()
    {
        if (!classificationSteps)
            classificationSteps = this;

    }

    // Update is called once per frame
    void Update()
    {

    }
}

