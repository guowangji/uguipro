using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellLine : MonoBehaviour {

    public GameObject cellA;
    public GameObject cellB;
    public float z;
    public Material mat;
    private Vector3 vBeg;
    private Vector3 vEnd;
    public Camera modeCamera;
    public static IList<Vector3> _posList = new List<Vector3>();

    public bool isReady=true;

    void Start() {
        //mat.hideFlags = HideFlags.HideAndDontSave;
        ////mat.color = Color.green;
        //mat.shader.hideFlags = HideFlags.HideAndDontSave;
        //OnPostRender();



        //获得游戏对象
        LineRenderGameObject = gameObject;//GameObject.Find("ObjLine");
        //获得线渲染器组件
        lineRenderer = LineRenderGameObject.GetComponent<LineRenderer>();
        //设置线的顶点数
        lineRenderer.positionCount = lineLength;
        //设置线的宽度
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        //StartCoroutine(waitme());
    }


    IEnumerator waitme()
    {
        yield return new WaitForSeconds(1f);
        lineRenderer.SetPosition(0, _posList[2]);
        lineRenderer.SetPosition(1, _posList[3]);
    }


    //线段对象
    private GameObject LineRenderGameObject;
    //线段渲染器
    private LineRenderer lineRenderer;
    //设置线段的顶点数，4个点确定3条直线
    private int lineLength =2;
    //记录4个点，连接一条线段
    private Vector3 v0 = new Vector3(1.0f, 0.0f, 0.0f);
    private Vector3 v1 = new Vector3(2.0f, 0.0f, 0.0f);
    private Vector3 v2 = new Vector3(3.0f, 0.0f, 0.0f);
    private Vector3 v3 = new Vector3(4.0f, 0.0f, 0.0f);

    void Update()
    {
        if (isReady)
        {
            for (int i = 0; i < _posList.Count - 1; i += 2)
            {
                //vBeg = GetComponent<Camera>().WorldToScreenPoint(_posList[i]);
                //vEnd = GetComponent<Camera>().WorldToScreenPoint(_posList[i + 1]);
                //GL.PushMatrix();
                //mat.SetPass(0);
                //GL.LoadOrtho();
                //GL.Begin(GL.LINES);

                //GL.Vertex3(vBeg.x / Screen.width, vBeg.y / Screen.height, z);
                //GL.Vertex3(vEnd.x / Screen.width, vEnd.y / Screen.height, z);

                //GL.End();
                //GL.PopMatrix();
                //        }
            }
            if (_posList.Count > 5)
            {
                //使用4个顶点渲染3条线段
                //lineRenderer.SetPosition(0, v0);
                lineRenderer.SetPosition(0, _posList[0]);
                lineRenderer.SetPosition(1, _posList[1]);
                
                //lineRenderer.SetPosition(3, v3);
            }
        }

    }







    //void OnPostRender() {
    //    if (isReady)
    //    {
    //        vBeg = GetComponent<Camera>().WorldToScreenPoint(cellA.transform.position);
    //        vEnd = GetComponent<Camera>().WorldToScreenPoint(cellB.transform.position);
    //        GL.PushMatrix(); //保存当前Matirx  
    //        mat.SetPass(0); //刷新当前材质  
    //        GL.Color(Color.yellow);
    //        GL.LoadOrtho();//设置pixelMatrix  

    //        GL.Begin(GL.LINES);
    //        GL.Vertex3(vBeg.x / Screen.width, vBeg.y / Screen.height, z);
    //        GL.Vertex3(vEnd.x / Screen.width, vEnd.y / Screen.height, z);
    //        GL.End();
    //        GL.PopMatrix();//读取之前的Matrix  

    //        for (int i = 0; i < _posList.Count - 1; i+=2)
    //        {
    //            vBeg = GetComponent<Camera>().WorldToScreenPoint(_posList[i]);
    //            vEnd = GetComponent<Camera>().WorldToScreenPoint(_posList[i + 1]);
    //            GL.PushMatrix();
    //            mat.SetPass(0);
    //            GL.LoadOrtho();
    //            GL.Begin(GL.LINES);

    //            GL.Vertex3(vBeg.x / Screen.width, vBeg.y / Screen.height, z);
    //            GL.Vertex3(vEnd.x / Screen.width, vEnd.y / Screen.height, z);

    //            GL.End();
    //            GL.PopMatrix();
    //        }
    //    }
    //}
}
