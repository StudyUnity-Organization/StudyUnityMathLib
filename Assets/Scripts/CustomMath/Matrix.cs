using CustomMath;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Matrix {  //для проверки гита х2

    public Vector4 X { get; private set; }
    public Vector4 Y { get; private set; }
    public Vector4 Z { get; private set; }

    public Vector4 W { get; private set; }
    //public Vector4[] Vectors;
    //List<Vector4> VectorsList;

    public Matrix(Vector4 x1, Vector4 y1, Vector4 z1, Vector4 w1) {

        X = x1;
        Y = y1;
        Z = z1;
        W = w1;
    }





    public static Matrix operator *(Matrix a, Matrix b) {

 
        float c11 = a.X.x * b.X.x + a.X.y * b.Y.x + a.X.z * b.Z.x + a.X.w * b.W.x;
        float c12 = a.X.x * b.X.y + a.X.y * b.Y.y + a.X.z * b.Z.y + a.X.w * b.W.y;
        float c13 = a.X.x * b.X.z + a.X.y * b.Y.z + a.X.z * b.Z.z + a.X.w * b.W.z;
        float c14 = a.X.x * b.X.w + a.X.y * b.Y.w + a.X.z * b.Z.w + a.X.w * b.W.w;

        float c21 = a.Y.x * b.X.x + a.Y.y * b.Y.x + a.Y.z * b.Z.x + a.Y.w * b.W.x;
        float c22 = a.Y.x * b.X.y + a.Y.y * b.Y.y + a.Y.z * b.Z.y + a.Y.w * b.W.y;
        float c23 = a.Y.x * b.X.z + a.Y.y * b.Y.z + a.Y.z * b.Z.z + a.Y.w * b.W.z;
        float c24 = a.Y.x * b.X.w + a.Y.y * b.Y.w + a.Y.z * b.Z.w + a.Y.w * b.W.w;

        float c31 = a.Z.x * b.X.x + a.Z.y * b.Y.x + a.Z.z * b.Z.x + a.Z.w * b.W.x;
        float c32 = a.Z.x * b.X.y + a.Z.y * b.Y.y + a.Z.z * b.Z.y + a.Z.w * b.W.y;
        float c33 = a.Z.x * b.X.z + a.Z.y * b.Y.z + a.Z.z * b.Z.z + a.Z.w * b.W.z;
        float c34 = a.Z.x * b.X.w + a.Z.y * b.Y.w + a.Z.z * b.Z.w + a.Z.w * b.W.w;

        float c41 = a.W.x * b.X.x + a.W.y * b.Y.x + a.W.z * b.Z.x + a.W.w * b.W.x;
        float c42 = a.W.x * b.X.y + a.W.y * b.Y.y + a.W.z * b.Z.y + a.W.w * b.W.y;
        float c43 = a.W.x * b.X.z + a.W.y * b.Y.z + a.W.z * b.Z.z + a.W.w * b.W.z;
        float c44 = a.W.x * b.X.w + a.W.y * b.Y.w + a.W.z * b.Z.w + a.W.w * b.W.w;


        Vector4 x = new Vector4(c11, c12, c13, c14);
        Vector4 y = new Vector4(c21, c22, c23, c24);
        Vector4 z = new Vector4(c31, c32, c33, c34);
        Vector4 w = new Vector4(c41, c42, c43, c44);

        Matrix c = new Matrix(x, y, z, w);


        return c;
    }





}
  
