using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewportDrawerInstance : MonoBehaviour
{
    public struct Line
    {
        Vector3 start, end;
        Color color;
        Material m;

        public Line(Vector3 start, Vector3 end, Color color)
        {
            this.start = start;
            this.end = end;
            this.color = color;
            m = new Material(Shader.Find("Unlit/Color"));
        }

        public void Draw(Camera camera)
        {
            GL.PushMatrix(); m.SetPass(0);
            m.SetColor("_Color", color);
            GL.LoadProjectionMatrix(camera.projectionMatrix);
            GL.Begin(GL.LINES);
            GL.Vertex(start);
            GL.Vertex(end);
            GL.End();
            GL.PopMatrix();
        }
    }

    public List<Line> lines = new List<Line>();

    private void OnPostRender()
    {
        for (int i = 0; i < lines.Count; i++)
            lines[i].Draw(GetComponent<Camera>());
        lines.Clear();
    }
}

public static class ViewportDrawer
{
    public static void DrawLine(Vector3 start, Vector3 end)
    {
        var lineDrawer = Camera.main.gameObject.EnsureComponent<ViewportDrawerInstance>();
        lineDrawer.lines.Add(new ViewportDrawerInstance.Line(start, end, Color.white));
    }

    public static void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        var lineDrawer = Camera.main.gameObject.EnsureComponent<ViewportDrawerInstance>();
        lineDrawer.lines.Add(new ViewportDrawerInstance.Line(start, end, color));
    }
}