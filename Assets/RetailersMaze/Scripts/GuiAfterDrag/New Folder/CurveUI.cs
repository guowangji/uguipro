using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurveUI : MonoBehaviour {
    public Material material;
    List<Vector2> lineInfo = new List<Vector2>();

    void Update()
    {
        lineInfo.Add(new Vector2(Time.time, Mathf.Sin(Time.time)));
    }

    void OnGUI()
    {
        GUI.backgroundColor = new Color(100f / 255, 160f / 255, 1);
        GUI.Label(new Rect(Screen.width - 75, Screen.height - 50, 100, 100), "Time");
        GUI.Label(new Rect(10, 25, 100, 100), "Sin(Time)");
        for (int i = 0; i < 3; i++)
            GUI.Label(new Rect(35, Screen.height - 60 - (Screen.height - 100) / 2 * i, 100, 100), (i-1).ToString());
    }

    void OnPostRender()
    {
        while (lineInfo.Count > 0 && lineInfo[0].x <= Time.time - 10)
        {
            lineInfo.RemoveAt(0);
        }
        if (lineInfo.Count == 0)
            return;
        float minX = lineInfo[0].x;
        material.SetPass(0);
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        float x = 50f / Screen.width;
        float y = 50f / Screen.height;
        float width = (float)(Screen.width - 100) / Screen.width;
        float height = (float)(Screen.height - 100) / Screen.height;
        GL.Vertex(new Vector3(x, y));
        GL.Vertex(new Vector3(x + width, y));
        GL.Vertex(new Vector3(x, y));
        GL.Vertex(new Vector3(x, y + height));
        for (int i = 0; i < lineInfo.Count - 1; i++)
        {
            print("sadasa"+ lineInfo.Count);
            Vector2 start = lineInfo[i];
            Vector2 end = lineInfo[i + 1];
            GL.Vertex(new Vector3(x + (start.x - minX) / 10 * width, y + (start.y + 1) / 2 * height, 0));
            GL.Vertex(new Vector3(x + (end.x - minX) / 10 * width, y + (end.y + 1) / 2 * height, 0));
        }
        GL.End();
    }
}
