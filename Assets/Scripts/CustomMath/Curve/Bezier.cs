using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using Unity.VisualScripting;
using System;

public static class Bezier {

    public static Vector3 BezierCurve(float t, List<Vector3> p) {
        if (p.Count < 2) {
            return p[0];
        }    
        for (int i = 0; i < p.Count - 1; i++) {
            Vector3 p0p1 = (1 - t) * p[i] + t * p[i + 1];
            //       newp.Add(p0p1);
            p[i] = p0p1;
        }
        p.RemoveAt(p.Count - 1);
        return BezierCurve(t, p);
    }

    public static Vector3 BezierCurve(float t, List<Transform> p, List<Vector3> positions) {
        if (p.Count < 2) {
            try {
                return p[0].position;
            } catch (Exception e) {
                return Vector3.zero;
            }
        }
        positions.Clear();
        for (int i = 0; i < p.Count; i++) {
            positions.Add(p[i].position);
        }
        return BezierCurve(t, positions);
    }



}


//public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) { 
//    Vector3 p01 = Vector3.Lerp(p0, p1, t);
//    Vector3 p12 = Vector3.Lerp(p1, p2, t);
//    Vector3 p23 = Vector3.Lerp(p2, p3, t);


//    Vector3 p012 = Vector3.Lerp(p01, p12, t);
//    Vector3 p123 = Vector3.Lerp(p12, p23, t);

//    Vector3 p0123 = Vector3.Lerp(p012, p123, t);

//    return p0123;
//}
