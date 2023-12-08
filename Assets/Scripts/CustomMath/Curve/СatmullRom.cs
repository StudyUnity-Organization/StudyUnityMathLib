using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class СatmullRom {
    public static float GetKnotInterval(Vector3 a, Vector3 b) {
        return Mathf.Pow(Vector3.SqrMagnitude(a - b), 0.5f);
    }

    static Vector3 Remap(float a, float b, Vector3 c, Vector3 d, float u) {
        return Vector3.LerpUnclamped(c, d, (u - a) / (b - a));
    }

    //алгорит построения
    public static Vector3 СatmullRomSpline(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3) {
        Vector3 p0p3 = Vector3.zero;

        float k0 = 0;
        float k1 = GetKnotInterval(p0, p1);
        float k2 = GetKnotInterval(p1, p2) + k1;
        float k3 = GetKnotInterval(p2, p3) + k2;

        float u = Mathf.LerpUnclamped(k1, k2, t);
        Vector3 A1 = Remap(k0, k1, p0, p1, u);
        Vector3 A2 = Remap(k1, k2, p1, p2, u);
        Vector3 A3 = Remap(k2, k3, p2, p3, u);
        Vector3 B1 = Remap(k0, k2, A1, A2, u);
        Vector3 B2 = Remap(k1, k3, A2, A3, u);
        p0p3 = Remap(k1, k2, B1, B2, u);

        return p0p3;
    }

    public static Vector3 СatmullRomSpline(float t, List<Vector3> p) {
        if (p.Count < 4) { //для построение нужно 4 точки
            return p[0];
        }

        Vector3 p0p3 = Vector3.zero;
        float rangeInitial = 0;                      //начальное значение диапазона, в который входит точка
        float rangeFinal = 1;                        //конечное значение диапазона, в который входит точка 
        float tNew = 1;                              //значение t для каждого учаска(между двумя точками)
        bool enterInDiapazon = false;                //попали ли мы в диапазон значений или нет
        int countPoint = 0;                          //счетчик точек
        List<Vector3> newp = new List<Vector3>();
        tNew = 1f / (p.Count - 3f);                  //нахожу значение t между точками (Например, так как t от 0 до 1, то при двух точках t = 0.5 :  для  первой точки - 0~0.5, для второй - 0,5~1)
        rangeFinal = tNew;
        while (!enterInDiapazon) {
            if (rangeInitial <= t && t <= rangeFinal) { //нахожу диапазон в который входит мое значение t
                enterInDiapazon = true;
            } else {
                rangeInitial += tNew;                   //сдвигаю диапазон            
                rangeFinal += tNew;
                countPoint++;
            }
        }
        t = Interpolation.Remap3D(rangeInitial, rangeFinal, 0, 1, t); //инвертирую значение t для всей кривой в значение для выбранного интервала
        return p0p3 = СatmullRomSpline(t, p[countPoint], p[countPoint + 1], p[countPoint + 2], p[countPoint + 3]);
    }


    public static Vector3 СatmullRomSpline(float t, List<Transform> p) {
        List<Vector3> newp = new List<Vector3>();
        for (int i = 0; i < p.Count; i++) {
            newp.Add(p[i].position);
        }
        return СatmullRomSpline(t, newp);
    }
}
