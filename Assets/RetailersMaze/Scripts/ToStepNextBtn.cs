using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToStepNextBtn : MonoBehaviour {
    public static int threeMenu;
	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(NextPage);
	}
	
    void NextPage()
    {
        switch (ToStepNextBtn.threeMenu)
        {
            case 1:
                ClassificationSteps.classificationSteps.lineBtn1.SetActive(true);
            ClassificationSteps.classificationSteps.step1.SetActive(true);
            ClassificationSteps.classificationSteps.step2.SetActive(false);
            ClassificationSteps.classificationSteps.step3.SetActive(false);
            ClassificationSteps.classificationSteps.notice.SetActive(true);
                ClassificationSteps.classificationSteps.noticeBtns.transform.parent = ClassificationSteps.classificationSteps.notice.transform.Find("noticeTopPlane");

                break;
            case 2:
            RegressionSteps.regressionSteps.lineBtn1.SetActive(true);
            //RegressionSteps.regressionSteps.lineBtn2.SetActive(false);
            //RegressionSteps.regressionSteps.lineBtn3.SetActive(false);
            RegressionSteps.regressionSteps.step1.SetActive(true);
            RegressionSteps.regressionSteps.step2.SetActive(false);
            RegressionSteps.regressionSteps.step3.SetActive(false);
            RegressionSteps.regressionSteps.notice.SetActive(true);
                break;
            case 3:
                ClusteringSteps.clusteringSteps.lineBtn1.SetActive(true);
                //ClusteringSteps.clusteringSteps.lineBtn2.SetActive(false);
                //ClusteringSteps.clusteringSteps.lineBtn3.SetActive(false);
                ClusteringSteps.clusteringSteps.step1.SetActive(true);
                ClusteringSteps.clusteringSteps.step2.SetActive(false);
                ClusteringSteps.clusteringSteps.step3.SetActive(false);
                ClusteringSteps.clusteringSteps.notice.SetActive(true);
                break;
        }

        }

}
