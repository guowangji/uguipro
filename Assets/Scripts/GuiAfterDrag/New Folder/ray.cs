using UnityEngine;

public class ray : MonoBehaviour {
    //Vector3[] vertices;
    //int[] triangles;
    //Vector2[] uv;
    //// Use this for initialization
    //void Start () {
    //    render = GetComponent<CanvasRenderer>();
    //    // 为网格创建顶点数组
    //   vertices = new Vector3[4]{
    //         //new Vector3(15, 15, 0),
    //         //new Vector3(-15, 15, 0),
    //         //new Vector3(15, -15, 0),
    //         //new Vector3(-15, -15, 0)

    //           new Vector3(20, 20, 0),
    //         new Vector3(-20, 20, 0),
    //         new Vector3(20, -20, 0),
    //         new Vector3(-20, -20, 0)
    //     };

    //     // 通过顶点为网格创建三角形
    //     triangles = new int[2 * 3]{
    //         0, 3, 1, 0, 2, 3
    //     };


    //    uv = new Vector2[4]{
    //        new Vector2(1, 1),
    //        new Vector2(0, 1),
    //        new Vector2(1, 0),
    //        new Vector2(0, 0)
    //    };

    //}

    //private CanvasRenderer render;

    //void Update()
    //{
    //    Mesh mesh = new Mesh();
    //    //mesh.SetVertices(vertices);      // 设置顶点，这里缩略没写出顶点数组
    //    mesh.vertices = vertices;
    //    //mesh.SetUVs();
    //    mesh.uv = uv;
    //    //mesh.SetTriangles();
    //    mesh.triangles = triangles;

    //    render = GetComponent<CanvasRenderer>();
    //    render.SetMesh(mesh);
    //}






    //public Material mat;
    //public Color color = Color.red;
    //public Vector3 pos1;
    //public Vector3 pos2;
    //public bool isReady = true;

    //void Start()
    //{
    //    mat.color = color;
    //    pos1 = point1.position;
    //    pos2 = point2.position;
    //}

    //void OnPostRender()
    //{
    //    if (isReady)
    //    {
    //        GL.PushMatrix();
    //        //mat.SetPass(4);
    //        GL.LoadOrtho();
    //        GL.Begin(GL.LINES);
    //        GL.Color(color);
    //        GL.Vertex3(pos1.x / Screen.width, pos1.y / Screen.height, pos1.z);
    //        GL.Vertex3(pos2.x / Screen.width, pos2.y / Screen.height, pos2.z);
    //        GL.End();
    //        GL.PopMatrix();
    //    }
    //}
    //public Mesh mesh;

    //public Material material;

    ////Update is called once per frame
    //void Update()
    //{
    //}


    //public Transform point1, point2, point3;
    ////public void OnDrawGizmosSelected()//OnDrawGizmos
    //public void OnDrawGizmos()//
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawLine(point1.position, point2.position);
    //    Gizmos.color = Color.cyan;
    //    Gizmos.DrawLine(point2.position, point3.position);

    //    Gizmos.color = Color.red;
    //    float ratio = 1f;
    //    Gizmos.DrawLine(Vector3.Lerp(point1.position, point2.position, ratio),
    //    Vector3.Lerp(point2.position, point3.position, ratio));
    //}




    public Material mat;
    public Color color = Color.red;
    public Vector3 pos1;
    public Vector3 pos2;

    void Start()
    {
        mat.color = color;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pos1 = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            pos2 = Input.mousePosition;
        }
    }

    void OnPostRender()
    {
        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        GL.Color(color);
        GL.Vertex3(pos1.x / Screen.width, pos1.y / Screen.height, 0);
        GL.Vertex3(pos2.x / Screen.width, pos1.y / Screen.height, 0);
        GL.Vertex3(pos2.x / Screen.width, pos1.y / Screen.height, 0);
        GL.Vertex3(pos2.x / Screen.width, pos2.y / Screen.height, 0);
        GL.Vertex3(pos2.x / Screen.width, pos2.y / Screen.height, 0);
        GL.Vertex3(pos1.x / Screen.width, pos2.y / Screen.height, 0);
        GL.Vertex3(pos1.x / Screen.width, pos2.y / Screen.height, 0);
        GL.Vertex3(pos1.x / Screen.width, pos1.y / Screen.height, 0);
        GL.End();
        GL.PopMatrix();
    }

}
