using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusteringSteps : MonoBehaviour
{
    public GameObject step1, step2, step3;//页面
    public GameObject lineBtn1, lineBtn2, lineBtn3;//按钮
    public GameObject notice, GLayoutGroup;
    public static ClusteringSteps clusteringSteps;
    // Use this for initialization
    void Start()
    {
        if (!clusteringSteps)
            clusteringSteps = this;

    }

    // Update is called once per frame
    void Update()
    {

    }
}


