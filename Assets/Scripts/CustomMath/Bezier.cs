using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier {

    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) { 
        Vector3 p01 = Vector3.Lerp(p0, p1, t);
        Vector3 p12 = Vector3.Lerp(p1, p2, t);
        Vector3 p23 = Vector3.Lerp(p2, p3, t);


        Vector3 p012 = Vector3.Lerp(p01, p12, t);
        Vector3 p123 = Vector3.Lerp(p12, p23, t);

        Vector3 p0123 = Vector3.Lerp(p012, p123, t);

        return p0123;
    }


    public static Vector3 BezierCurve(float t, List<Vector3> p) {
        if (p.Count < 2)
            return p[0];
        List<Vector3> newp = new List<Vector3>();
        for (int i = 0; i < p.Count - 1; i++) {
          //  Debug.DrawLine(p[i], p[i + 1]);
            Vector3 p0p1 = (1 - t) * p[i] + t * p[i + 1];
            newp.Add(p0p1);
        }
        return BezierCurve(t, newp);
    }
    // преобразовываем преобразование в vector3, вызываем функцию Безье с параметром List <Vector3>
    public static Vector3 BezierCurve(float t, List<Transform> p) {
        if (p.Count < 2)
            return p[0].position;
        List<Vector3> newp = new List<Vector3>();
        for (int i = 0; i < p.Count; i++) {
            newp.Add(p[i].position);
        }
        return BezierCurve(t, newp);
    }


    public static Vector3 BezierCurveDrawLine(float t, List<Vector3> p) {
        if (p.Count < 2)
            return p[0];
        List<Vector3> newp = new List<Vector3>();
        for (int i = 0; i < p.Count - 1; i++) {
            Debug.DrawLine(p[i], p[i + 1]);
            Vector3 p0p1 = (1 - t) * p[i] + t * p[i + 1];
            newp.Add(p0p1);
        }
        return BezierCurve(t, newp);
    }
    // преобразовываем преобразование в vector3, вызываем функцию Безье с параметром List <Vector3>
    public static Vector3 BezierCurveDrawLine(float t, List<Transform> p) {
        if (p.Count < 2)
            return p[0].position;
        List<Vector3> newp = new List<Vector3>();
        for (int i = 0; i < p.Count; i++) {
            newp.Add(p[i].position);
        }
        return BezierCurve(t, newp);
    }




}
