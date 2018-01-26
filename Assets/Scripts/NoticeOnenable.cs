using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeOnenable : MonoBehaviour {
    public int btnNick = 1;
	// Use this for initialization
	void Start () {
        print("aaas"+gameObject.name);

        if (btnNick == 1)
        {
            GetComponent<Button>().onClick.AddListener(NoticeTopPanel);
        }else 
        {
            GetComponent<Button>().onClick.AddListener(NoticeTopPanelEnd);
        }
	}

    void NoticeTopPanel()
    {
        ClassificationSteps.classificationSteps.noticeAxisArea.transform.parent = ClassificationSteps.classificationSteps.notice.transform.Find("noticeTopPlane");
        ClassificationSteps.classificationSteps.noticeBtns.transform.parent = ClassificationSteps.classificationSteps.step1.transform;
    }

    void NoticeTopPanelEnd()
    {
        //ClassificationSteps.classificationSteps.noticeAxisArea.transform.parent = ClassificationSteps.classificationSteps.notice.transform.Find("noticeTopPlane");
        ClassificationSteps.classificationSteps.noticeAxisArea.transform.parent = ClassificationSteps.classificationSteps.step1.transform;
       Transform topPanel = ClassificationSteps.classificationSteps.step1.transform.Find("btnTopPanel");
        topPanel.parent= ClassificationSteps.classificationSteps.notice.transform.Find("noticeTopPlane");
        topPanel.parent = ClassificationSteps.classificationSteps.step1.transform;
    }
}

