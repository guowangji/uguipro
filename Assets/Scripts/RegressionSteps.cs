using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegressionSteps : MonoBehaviour
{
    public GameObject step1, step2, step3;//页面
    public GameObject lineBtn1, lineBtn2, lineBtn3;//按钮
    public GameObject notice;
    public static RegressionSteps regressionSteps;
    // Use this for initialization
    void Start()
    {
        if (!regressionSteps)
            regressionSteps = this;

    }

}


