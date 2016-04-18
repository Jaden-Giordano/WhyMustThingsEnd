using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PolyTool {

    public static Mesh CreatePolygon(int verts, Color color) {
        Vector3[] vertices = new Vector3[verts];
        int[] triangles = new int[(verts - 2)*3];
        Color[] colors = new Color[verts];

        for (int i = 0; i < vertices.Length; i++) {
            vertices[i] = new Vector3(Mathf.Cos(Mathf.Deg2Rad * ((vertices.Length-1)-i * (360 / verts))), Mathf.Sin(Mathf.Deg2Rad * ((vertices.Length - 1) - i * (360 / verts))));
            colors[i] = color;
        }

        for (int i = 0; i < verts-2; i++) {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        Mesh poly = new Mesh();
        poly.vertices = vertices;
        poly.triangles = triangles;
        poly.colors = colors;

        return poly;
    }

    public static Vector2[] CreateCollider(int verts) {
        Vector2[] array = new Vector2[verts];
        for (int i = 0; i < array.Length; i++) {
            array[i] = new Vector3(Mathf.Cos(Mathf.Deg2Rad * ((array.Length - 1) - i * (360 / verts))), Mathf.Sin(Mathf.Deg2Rad * ((array.Length - 1) - i * (360 / verts))));
        }
        return array;
    }

    public static Color[] SetColor(PolyType ptype, Color color) {
        Color[] c = new Color[(int)ptype];

        for (int i = 0; i < c.Length; i++) {
            c[i] = color;
        }

        return c;
    }

}
