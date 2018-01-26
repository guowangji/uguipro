using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GLDrawLine : MonoBehaviour {
    public static GLDrawLine _instance;
    public Material material;//>Gl材质
    //public mainUIController Mc = mainUIController._instance;
    public List<Vector2> GLPoints = new List<Vector2>();//>Gl画线点
    public Color glColor = Color.red;//>GL颜色
    public bool isSmooth = false;
    void Awake()
    {
        _instance = this;
    }



    public void ClearGLDraw()
    {
        GLPoints.Clear();
    }
    #region GlDrawLine
    //****************************************GlDrawLine****************************************//
    void OnPostRender()
    {
        if (!material)
        {
            print("请给材质资源赋值");
            return;
        }
        if (GLPoints.Count > 0)
        {
            // 设置材质的通道
            material.SetPass(0);
            // 三维图形，此方法不可用
            GL.LoadOrtho();
            //表示开始绘制，绘制类型为线段
            GL.Begin(GL.LINES);
            GL.Color(glColor);
            GLDrawGraph(GLPoints);
            GL.End();
        }

    }
    public void OpenGlDrawLine(List<GameObject> point)
    {
        List<Vector2> _points = new List<Vector2>();
        for (int i = 0; i < point.Count; i++)
        {
            _points.Add(point[i].transform.position);
        }
        if (_points.Count == point.Count && _points.Count>0)
        {
            List<Vector2> REPoint = new List<Vector2>();
            for (int i = 0; i < point.Count; i++)
            {
                REPoint.Add(GetComponent<Camera>().WorldToScreenPoint(_points[i]));
            }
            GLPoints = REPoint;
        }
    }
    public void OpenGlDrawLine(List<Vector2> point)
    {
        if (point.Count > 0)
        {
            List<Vector2> REPoint = new List<Vector2>();
            for (int i = 0; i < point.Count; i++)
            {
                REPoint.Add(GetComponent<Camera>().WorldToScreenPoint(point[i]));
            }
            GLPoints = REPoint;
        }
    }
    public void OpenGlDrawLine(List<Vector2> point1, List<Vector2> point2)
    {
        if (point1.Count > 0)
        {
            List<Vector2> REPoint = new List<Vector2>();
            for (int i = 0; i < point1.Count; i++)
            {
                REPoint.Add(GetComponent<Camera>().WorldToScreenPoint(point1[i]));
            }
            GLPoints = REPoint;
        }
    }
    /// <summary>
    /// GL线段首尾连接
    /// </summary>
    /// <param name="point"></param>
    public void GLDrawGraph(List<Vector2> point)
    {
        if (point.Count>0)
        {
            for (int i = 0; i < point.Count - 1; i++)
            {
                DrawLine(point[i], point[i + 1]);
            }

            if (isSmooth)
            {
                GL.Color(Color.blue);
                DrawLine(point[point.Count - 2], point[point.Count - 1]);
                DrawLine(point[0], point[point.Count - 1]);
            }
            else
            {
                DrawLine(point[0], point[point.Count - 1]);
            }
        }
    }
    #region 废弃的方法
    ///// <summary>
    ///// 方框方法
    ///// </summary>
    ///// <param name="from"></param>
    ///// <param name="to"></param>
    //public void PaintRect(Vector2 from, Vector2 to)
    //{
    //    DrawLine(from.x, from.y, new Vector2(to.x, from.y).x, new Vector2(to.x, from.y).y);
    //    DrawLine(new Vector2(to.x, from.y).x, new Vector2(to.x, from.y).y, to.x, to.y);
    //    DrawLine(to.x, to.y, new Vector2(from.x, to.y).x, new Vector2(from.x, to.y).y);
    //    DrawLine(new Vector2(from.x, to.y).x, new Vector2(from.x, to.y).y, from.x, from.y);
    //}
    ///// <summary>
    ///// GL预览画圆
    ///// </summary>
    //public float m_Radius = 1; // 圆环的半径
    //public float m_Theta = 0.1f; // 值越低圆环越平滑
    ////旋转改变的角度
    //public float changeAngle = 1;
    ////旋转一周需要的预制物体个数
    //private float count;
    //private float angle = 0;
    //public float r = 100;
    //private List<Vector2> roundnessArray;
    //public void PaintRound(Vector2 from, Vector2 to)
    //{
    //    roundnessArray.Clear();
    //    r = Vector2.Distance(from, to);
    //    count = 360f / changeAngle;
    //    for (int i = 0; i < count; i++)
    //    {
    //        Vector3 center = from;
    //        float hudu = (angle / 180) * Mathf.PI;
    //        float xx = center.x + r * Mathf.Cos(hudu);
    //        float yy = center.y + r * Mathf.Sin(hudu);
    //        roundnessArray.Add(new Vector2(xx, yy));
    //        angle += changeAngle;
    //    }
    //    for (int i = 0; i < roundnessArray.Count; i++)
    //    {
    //        if (i < roundnessArray.Count - 1)
    //        {
    //            DrawLine(roundnessArray[i].x, roundnessArray[i].y, roundnessArray[i + 1].x, roundnessArray[i + 1].y);
    //        }
    //    }
    //}

    ///// <summary>
    ///// GL预览画三角形，模仿Windows画板
    ///// </summary>
    ///// <param name="from"></param>
    ///// <param name="to"></param>
    //public void PaintTriangle(Vector2 from, Vector2 to)
    //{
    //    float w = to.x - from.x;
    //    float h = from.y - to.y;
    //    DrawLine(from.x, from.y - h, from.x + w / 2, from.y);
    //    DrawLine(from.x + w / 2, from.y, to.x, to.y);
    //    DrawLine(from.x, from.y - h, to.x, to.y);
    //}
    ///// <summary>
    ///// GL预览画曲线
    ///// </summary>
    ///// <param name="from"></param>
    ///// <param name="to"></param>
    //public Transform _Point01;
    //public Transform _Point02;
    //public Transform _Point03;
    //Vector3 Point01;
    //Vector3 Point02;
    //Vector3 Point03;
    //// When added to an object, draws colored rays from the
    //// transform position.
    //public int lineCount = 100;
    //public float radius = 3.0f;
    ////算法公式类
    //private Bezier myBezier;
    //private List<Vector3> PointBezier = new List<Vector3>();
    //private bool hideLine;

    //public void PaintSmoothcurve(Vector2 from, Vector2 to)
    //{
    //    PointBezier.Clear();
    //    //中间的标志点分别减去左右两边的标志点，计算出曲线的X Y 的点  
    //    //print(Input.mousePosition + "||||||" + UICamera.currentCamera.WorldToScreenPoint(Point01.position));
    //    Point01 = UICamera.currentCamera.WorldToScreenPoint(_Point01.position);
    //    Point02 = UICamera.currentCamera.WorldToScreenPoint(_Point02.position);
    //    Point03 = UICamera.currentCamera.WorldToScreenPoint(_Point03.position);
    //    float y = (Point03.y - Point02.y);
    //    float x = (Point03.x - Point02.x);

    //    myBezier = new Bezier(new Vector3(Point02.x, Point02.y, 0), new Vector3(x, y, 0f), new Vector3(0f, 0f, 0f), new Vector3(Point01.x, Point01.y, 0));
    //    //绘制贝塞尔曲线
    //    for (int i = 1; i <= 100; i++)
    //    {
    //        Vector3 vec = myBezier.GetPointAtTime((float)(i * 0.01));
    //        PointBezier.Add(vec);
    //        //print(PointBezier[i]);
    //    }
    //    if (hideLine)
    //    {
    //        for (int i = 0; i < PointBezier.Count - 1; i++)
    //        {
    //            DrawLine(PointBezier[i], PointBezier[i + 1]);
    //        }
    //        //DrawLine(Point01.localPosition, Point02.localPosition);
    //        GL.Color(Color.blue);
    //        DrawLine(Point01, Point03);
    //        DrawLine(Point02, Point03);
    //    }

    //}
    #endregion
    /// <summary>
    /// 绘制线的方法（传）
    /// </summary>
    /// <param name="x1"></param>
    /// <param name="y1"></param>
    /// <param name="x2"></param>
    /// <param name="y2"></param>
    private void DrawLine(float x1, float y1, float x2, float y2)
    {
        // 绘制线段，需要将屏幕中某个点的像素坐标点除以屏幕完成宽或高
        GL.Vertex(new Vector3(x1 / Screen.width, y1 / Screen.height, 0));
        GL.Vertex(new Vector3(x2 / Screen.width, y2 / Screen.height, 0));
    }
    /// <summary>
    /// 传坐标点
    /// </summary>
    /// <param name="_from"></param>
    /// <param name="_to"></param>
    private void DrawLine(Vector3 _from, Vector3 _to)
    {
        // 绘制线段，需要将屏幕中某个点的像素坐标点除以屏幕完成宽或高
        GL.Vertex(new Vector2(_from.x / Screen.width, _from.y / Screen.height));
        GL.Vertex(new Vector2(_to.x / Screen.width, _to.y / Screen.height));
    }
    //****************************************GlDrawLine****************************************//
    #endregion


}
