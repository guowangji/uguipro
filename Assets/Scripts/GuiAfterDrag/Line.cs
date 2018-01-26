using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line : MonoBehaviour
{

    public Transform begin;
    public float z;
    public Material mat;
    private Vector3 vBeg;
    private Vector3 vEnd;
    private static IList<Vector3> _posList = new List<Vector3>();

    private static bool _isReady = false;
    public static bool isReady
    {
        set { _isReady = value; }
    }

    void Start()
    {
        //mat = new Material("Shader \"Lines/Colored Blended\" {" +
        //                       "SubShader { Pass { " +
        //                       "    Blend SrcAlpha OneMinusSrcAlpha " +
        //                       "    ZWrite Off Cull Off Fog { Mode Off } " +
        //                       "    BindChannels {" +
        //                       "      Bind \"vertex\", vertex Bind \"color\", color }" +
        //                       "} } }");//生成画线的材质    
        mat.hideFlags = HideFlags.HideAndDontSave;
        mat.color = Color.green;
        mat.shader.hideFlags = HideFlags.HideAndDontSave;
    }
    public static void setPosList(ref IList<Vector3> posList)
    {
        if (_isReady)
        {
            return;
        }
        _posList = posList;
        if (_posList.Count > 1)
        {
            _isReady = true;
        }
    }
    void OnPostRender()
    {
        if (_isReady)
        {
            vBeg = GetComponent<Camera>().WorldToScreenPoint(begin.position);
            vEnd = GetComponent<Camera>().WorldToScreenPoint(_posList[0]);
            GL.PushMatrix(); //保存当前Matirx  
            mat.SetPass(0); //刷新当前材质  
            GL.LoadOrtho();//设置pixelMatrix  
            GL.Color(Color.yellow);
            GL.Begin(GL.LINES);
            GL.Vertex3(vBeg.x / Screen.width, vBeg.y / Screen.height, z);
            GL.Vertex3(vEnd.x / Screen.width, vEnd.y / Screen.height, z);
            GL.End();
            GL.PopMatrix();//读取之前的Matrix  

            for (int i = 0; i < _posList.Count - 1; ++i)
            {
                vBeg = GetComponent<Camera>().WorldToScreenPoint(_posList[i]);
                vEnd = GetComponent<Camera>().WorldToScreenPoint(_posList[i + 1]);
                GL.PushMatrix();
                mat.SetPass(0);
                GL.LoadOrtho();
                //              GL.LoadPixelMatrix();  
                GL.Begin(GL.LINES);
                GL.Color(Color.green);

                GL.Vertex3(vBeg.x / Screen.width, vBeg.y / Screen.height, z);
                GL.Vertex3(vEnd.x / Screen.width, vEnd.y / Screen.height, z);
                //              GL.Vertex3( vBeg.x, vBeg.y, 0 );    
                //              GL.Vertex3( vEnd.x, vEnd.y, 0 );    

                GL.End();
                GL.PopMatrix();
            }
        }
    }
}
