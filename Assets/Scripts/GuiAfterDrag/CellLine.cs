using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellLine : MonoBehaviour {

    public GameObject start, end;
    LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        //设置线的宽度
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;

        StartCoroutine(waitme());
    }


    IEnumerator waitme()
    {
        yield return new WaitForSeconds(0.5f);
        if (start && end)
            isRead = true;
        else
        {
            print("lostObj");
            StartCoroutine(waitme());
        }
    }

    bool isRead = false;
    int updateTime = 0;
        private void Update()
    {
        if (!isRead)
            return;

        if (updateTime < 10)
        {
            updateTime++;
            return;
        }
        else updateTime = 0;

        if (!start || !end)
        {
            Destroy(gameObject);
            return;
        }
        line.SetPosition(0, start.transform.position);
        line.SetPosition(1, end.transform.position);
    }







}
