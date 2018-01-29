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
        mat.hideFlags = HideFlags.HideAndDontSave;
        //mat.color = Color.green;
        mat.shader.hideFlags = HideFlags.HideAndDontSave;
        //OnPostRender();
    }
    void OnPostRender() {
        if (isReady)
        {
            vBeg = GetComponent<Camera>().WorldToScreenPoint(cellA.transform.position);
            vEnd = GetComponent<Camera>().WorldToScreenPoint(cellB.transform.position);
            GL.PushMatrix(); //保存当前Matirx  
            mat.SetPass(0); //刷新当前材质  
            GL.LoadOrtho();//设置pixelMatrix  
            GL.Color(Color.yellow);
            GL.Begin(GL.LINES);
            GL.Vertex3(vBeg.x / Screen.width, vBeg.y / Screen.height, z);
            GL.Vertex3(vEnd.x / Screen.width, vEnd.y / Screen.height, z);
            GL.End();
            GL.PopMatrix();//读取之前的Matrix  

            for (int i = 0; i < _posList.Count - 1; i+=2)
            {
                vBeg = GetComponent<Camera>().WorldToScreenPoint(_posList[i]);
                vEnd = GetComponent<Camera>().WorldToScreenPoint(_posList[i + 1]);
                GL.PushMatrix();
                mat.SetPass(0);
                GL.LoadOrtho();
                GL.Begin(GL.LINES);

                GL.Vertex3(vBeg.x / Screen.width, vBeg.y / Screen.height, z);
                GL.Vertex3(vEnd.x / Screen.width, vEnd.y / Screen.height, z);

                GL.End();
                GL.PopMatrix();
            }
        }
    }
}
