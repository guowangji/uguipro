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
        line.startWidth = 0.01f;
        line.endWidth = 0.01f;

        StartCoroutine(waitme());
    }


    IEnumerator waitme()
    {
        //yield return 0;
        yield return new WaitForSeconds(0.01f);
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

        //卡的话少刷几次
        //if (updateTime < 3)
        //{
        //    updateTime++;
        //    return;
        //}
        //else updateTime = 0;

        if (!start || !end)
        {
            Destroy(gameObject);
            return;
        }
        if(line.GetPosition(0)!= start.transform.position)
        line.SetPosition(0, start.transform.position);
        if (line.GetPosition(1) != end.transform.position)
        line.SetPosition(1, end.transform.position);
    }







}
