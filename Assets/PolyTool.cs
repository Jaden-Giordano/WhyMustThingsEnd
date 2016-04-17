using UnityEngine;
using System.Collections.Generic;

public class PolyTool {

    public static Mesh CreateTriangle() {
        List<Vector3> verticies = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Color> colors = new List<Color>();

        Vector3 v1 = new Vector3(0, 1);
        Vector3 v2 = new Vector3(0.86602f, -0.5f);
        Vector3 v3 = new Vector3(-0.86602f, -0.5f);

        verticies.Add(v1);
        verticies.Add(v2);
        verticies.Add(v3);

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v2));
        triangles.Add(verticies.IndexOf(v3));

        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);

        Mesh triangle = new Mesh();
        triangle.vertices = verticies.ToArray();
        triangle.triangles = triangles.ToArray();
        triangle.colors = colors.ToArray();
        
        return triangle;
    }

    public static Vector2[] CreateTriangleCollider() {
        List<Vector2> verticies = new List<Vector2>();

        Vector2 v1 = new Vector2(0, 1);
        Vector2 v2 = new Vector2(0.86602f, -0.5f);
        Vector2 v3 = new Vector2(-0.86602f, -0.5f);

        verticies.Add(v1);
        verticies.Add(v2);
        verticies.Add(v3);

        return verticies.ToArray();
    }

    public static Mesh CreateSquare() {
        List<Vector3> verticies = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uv = new List<Vector2>();
        List<Color> colors = new List<Color>();

        Vector3 v1 = new Vector3(-0.707107f, 0.707107f);
        Vector3 v2 = new Vector3(0.707107f, 0.707107f);
        Vector3 v3 = new Vector3(0.707107f, -0.707107f);
        Vector3 v4 = new Vector3(-0.707107f, -0.707107f);

        verticies.Add(v1);
        verticies.Add(v2);
        verticies.Add(v3);
        verticies.Add(v4);

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v2));
        triangles.Add(verticies.IndexOf(v3));

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v3));
        triangles.Add(verticies.IndexOf(v4));

        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);

        Mesh square = new Mesh();
        square.vertices = verticies.ToArray();
        square.triangles = triangles.ToArray();
        square.colors = colors.ToArray();

        return square;
    }

    public static Vector2[] CreateSquareCollider() {
        List<Vector2> verticies = new List<Vector2>();

        Vector2 v1 = new Vector2(-0.707107f, 0.707107f);
        Vector2 v2 = new Vector2(0.707107f, 0.707107f);
        Vector2 v3 = new Vector2(0.707107f, -0.707107f);
        Vector2 v4 = new Vector2(-0.707107f, -0.707107f);

        verticies.Add(v1);
        verticies.Add(v2);
        verticies.Add(v3);
        verticies.Add(v4);

        return verticies.ToArray();
    }

    public static Mesh CreatePentagon() {
        List<Vector3> verticies = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uv = new List<Vector2>();
        List<Color> colors = new List<Color>();

        Vector3 v1 = new Vector3(0, 1);
        Vector3 v2 = new Vector3(0.9510565f, 0.309017f);
        Vector3 v3 = new Vector3(0.5877853f, -0.809017f);
        Vector3 v4 = new Vector3(-0.5877853f, -0.809017f);
        Vector3 v5 = new Vector3(-0.9510565f, 0.309017f);

        verticies.Add(v1);
        verticies.Add(v2);
        verticies.Add(v3);
        verticies.Add(v4);
        verticies.Add(v5);

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v2));
        triangles.Add(verticies.IndexOf(v3));

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v3));
        triangles.Add(verticies.IndexOf(v4));

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v4));
        triangles.Add(verticies.IndexOf(v5));

        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);

        Mesh pentagon = new Mesh();
        pentagon.vertices = verticies.ToArray();
        pentagon.triangles = triangles.ToArray();
        pentagon.colors = colors.ToArray();

        return pentagon;
    }

    public static Vector2[] CreatePentagonCollider() {
        List<Vector2> verticies = new List<Vector2>();

        Vector2 v1 = new Vector2(0, 1);
        Vector2 v2 = new Vector2(0.9510565f, 0.309017f);
        Vector2 v3 = new Vector2(0.5877853f, -0.809017f);
        Vector2 v4 = new Vector2(-0.5877853f, -0.809017f);
        Vector2 v5 = new Vector2(-0.9510565f, 0.309017f);

        verticies.Add(v1);
        verticies.Add(v2);
        verticies.Add(v3);
        verticies.Add(v4);
        verticies.Add(v5);

        return verticies.ToArray();
    }

    public static Mesh CreateHexagon() {
        List<Vector3> verticies = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uv = new List<Vector2>();
        List<Color> colors = new List<Color>();

        Vector3 v1 = new Vector3(0, 1);
        Vector3 v2 = new Vector3(0.8660254f, 0.5f);
        Vector3 v3 = new Vector3(0.8660254f, -0.5f);
        Vector3 v4 = new Vector3(0, -1);
        Vector3 v5 = new Vector3(-0.8660254f, -0.5f);
        Vector3 v6 = new Vector3(-0.8660254f, 0.5f);

        verticies.Add(v1);
        verticies.Add(v2);
        verticies.Add(v3);
        verticies.Add(v4);
        verticies.Add(v5);
        verticies.Add(v6);

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v2));
        triangles.Add(verticies.IndexOf(v3));

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v3));
        triangles.Add(verticies.IndexOf(v4));

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v4));
        triangles.Add(verticies.IndexOf(v5));

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v5));
        triangles.Add(verticies.IndexOf(v6));

        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);

        Mesh hexagon = new Mesh();
        hexagon.vertices = verticies.ToArray();
        hexagon.triangles = triangles.ToArray();
        hexagon.colors = colors.ToArray();

        return hexagon;
    }

    public static Vector2[] CreateHexagonCollider() {
        List<Vector2> verticies = new List<Vector2>();

        Vector2 v1 = new Vector2(0, 1);
        Vector2 v2 = new Vector2(0.8660254f, 0.5f);
        Vector2 v3 = new Vector2(0.8660254f, -0.5f);
        Vector2 v4 = new Vector2(0, -1);
        Vector2 v5 = new Vector2(-0.8660254f, -0.5f);
        Vector2 v6 = new Vector2(-0.8660254f, 0.5f);

        verticies.Add(v1);
        verticies.Add(v2);
        verticies.Add(v3);
        verticies.Add(v4);
        verticies.Add(v5);
        verticies.Add(v6);

        return verticies.ToArray();
    }

    public static Mesh CreateOctagon() {
        List<Vector3> verticies = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uv = new List<Vector2>();
        List<Color> colors = new List<Color>();

        Vector3 v1 = new Vector3(0, 1);
        Vector3 v2 = new Vector3(0.70710678f, 0.70710678f);
        Vector3 v3 = new Vector3(1, 0);
        Vector3 v4 = new Vector3(0.70710678f, -0.70710678f);
        Vector3 v5 = new Vector3(0, -1);
        Vector3 v6 = new Vector3(-0.70710678f, -0.70710678f);
        Vector3 v7 = new Vector3(-1, 0);
        Vector3 v8 = new Vector3(-0.70710678f, 0.70710678f);

        verticies.Add(v1);
        verticies.Add(v2);
        verticies.Add(v3);
        verticies.Add(v4);
        verticies.Add(v5);
        verticies.Add(v6);
        verticies.Add(v7);
        verticies.Add(v8);

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v2));
        triangles.Add(verticies.IndexOf(v3));

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v3));
        triangles.Add(verticies.IndexOf(v4));

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v4));
        triangles.Add(verticies.IndexOf(v5));

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v5));
        triangles.Add(verticies.IndexOf(v6));

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v6));
        triangles.Add(verticies.IndexOf(v7));

        triangles.Add(verticies.IndexOf(v1));
        triangles.Add(verticies.IndexOf(v7));
        triangles.Add(verticies.IndexOf(v8));

        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);
        colors.Add(Color.black);

        Mesh octagon = new Mesh();
        octagon.vertices = verticies.ToArray();
        octagon.triangles = triangles.ToArray();
        octagon.colors = colors.ToArray();

        return octagon;
    }

    public static Vector2[] CreateOctagonCollider() {
        List<Vector2> verticies = new List<Vector2>();

        Vector2 v1 = new Vector2(0, 1);
        Vector2 v2 = new Vector2(0.70710678f, 0.70710678f);
        Vector2 v3 = new Vector2(1, 0);
        Vector2 v4 = new Vector2(0.70710678f, -0.70710678f);
        Vector2 v5 = new Vector2(0, -1);
        Vector2 v6 = new Vector2(-0.70710678f, -0.70710678f);
        Vector2 v7 = new Vector2(-1, 0);
        Vector2 v8 = new Vector2(-0.70710678f, 0.70710678f);

        verticies.Add(v1);
        verticies.Add(v2);
        verticies.Add(v3);
        verticies.Add(v4);
        verticies.Add(v5);
        verticies.Add(v6);
        verticies.Add(v7);
        verticies.Add(v8);

        return verticies.ToArray();
    }

    public static Color[] SetColor(PolyType ptype, Color color) {
        Color[] c = new Color[(int)ptype];

        for (int i = 0; i < c.Length; i++) {
            c[i] = color;
        }

        return c;
    }

}
