using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;

public static class MatrixRotation 
{
    //возвращает матрицу перемещения - используется в TRS
    public static Matrix TranslationMatrixTRS(Vector4 transform) {        
        Vector4 x = new Vector4(1, 0, 0, transform.x);
        Vector4 y = new Vector4(0, 1, 0, transform.y);
        Vector4 z = new Vector4(0, 0, 1, transform.z);
        Vector4 w = new Vector4(0, 0, 0, 1);
        return new Matrix(x, y, z, w);
    }

    //возвращает матрицу перемещения * на поцизию объекта - не нужно
    public static Matrix TranslationMatrixTRSxPosition(Vector3 objectPos, Vector4 transform) {
        Vector4 position = new Vector4(objectPos.x, objectPos.y, objectPos.z, 1);
        Vector4 x = MultiplicationMatrixComponents(new Vector4(1, 0, 0, transform.x), position);
        Vector4 y = MultiplicationMatrixComponents(new Vector4(0, 1, 0, transform.y), position);
        Vector4 z = MultiplicationMatrixComponents(new Vector4(0, 0, 1, transform.z), position);
        Vector4 w = MultiplicationMatrixComponents(new Vector4(0, 0, 0, 1), position);
        return new Matrix(x, y, z, w);
    }
    //[x  y  z  w]            [objectPos]

    //[1  0  0 transform.x]   [objectPos.x]
    //[0  1  0 transform.y]   [objectPos.y]
    //[0  0  1 transform.z]   [objectPos.z]
    //[0  0  0 1]             [1]

    //возвращает матрицу вращения - используется в TRS
    public static Matrix RotationMatrixTRS(Vector3 angle) {
        angle = angle * Mathf.Deg2Rad;

        Matrix rotX;
        Matrix rotY;
        Matrix rotZ;

        float sinX = Mathf.Sin(angle.x);
        float cosX = Mathf.Cos(angle.x);
        float sinY = Mathf.Sin(angle.y);
        float cosY = Mathf.Cos(angle.y);
        float sinZ = Mathf.Sin(angle.z);
        float cosZ = Mathf.Cos(angle.z);     

        Vector4 xRotX = new Vector4(1, 0, 0, 0);
        Vector4 yRotX = new Vector4(0, cosX, -sinX, 0);
        Vector4 zRotX = new Vector4(0, sinX, cosX, 0);
        Vector4 wRotX = new Vector4(0, 0, 0, 1);
        rotX = new Matrix(xRotX, yRotX, zRotX, wRotX);

        Vector4 xRotY = new Vector4(cosY, 0, sinY, 0);
        Vector4 yRotY = new Vector4(0, 1, 0, 0);
        Vector4 zRotY = new Vector4(-sinY, 0, cosY, 0);
        Vector4 wRotY = new Vector4(0, 0, 0, 1);
        rotY = new Matrix(xRotY, yRotY, zRotY, wRotY);

        Vector4 xRotZ = new Vector4(cosZ, -sinZ, 0, 0);
        Vector4 yRotZ = new Vector4(sinZ, cosZ, 0, 0);
        Vector4 zRotZ = new Vector4(0, 0, 1, 0);
        Vector4 wRotZ = new Vector4(0, 0, 0, 1);
        rotZ = new Matrix(xRotZ, yRotZ, zRotZ, wRotZ);

        Matrix rotationXYZ = rotX * rotY * rotZ;

        return rotationXYZ;   
    }
    //                               [objectRot]    
    //    Rotation around X axis: 
    //    [1  0     0   0]           [objectRot.x]
    //    [0 cosθ -sinθ 0]           [objectRot.y]
    //    [0 sinθ  cosθ 0]           [objectRot.z]
    //    [0  0     0   1]           [objectRot.z]
    //
    //    Rotation around Y axis:  
    //    [cosθ 0 sinθ 0]            [objectRot.x]
    //    [  0   1  0   0]           [objectRot.y]
    //    [-sinθ 0 cosθ 0]           [objectRot.z]
    //    [  0   0  0   1]           [objectRot.z]
    //                      
    //    Rotation around Z axis:
    //    [cosθ -sinθ 0 0]           [objectRot.x]
    //    [sinθ  cosθ 0 0]           [objectRot.y]
    //    [ 0     0   1 0]           [objectRot.z]
    //    [ 0     0   0 1]           [objectRot.z]


    //возвращает матрицу масштабирования - используется в TRS
    public static Matrix ScaleMatrixTRS(Vector3 scale) {

        Vector4 x = new Vector4(scale.x, 0, 0, 0);
        Vector4 y = new Vector4(0, scale.y, 0, 0);
        Vector4 z = new Vector4(0, 0, scale.z, 0);
        Vector4 w = new Vector4(0, 0, 0, 1);
      
        return new Matrix(x, y, z, w);   
    }



    public static Matrix4x4 TRSMatrix4x4(Vector4 transform, Vector3 angle, Vector3 scale) {

        Matrix t = TranslationMatrixTRS(transform);
        Matrix r = RotationMatrixTRS(angle);
        Matrix s = ScaleMatrixTRS(scale);

        Matrix TRSMatrix = t * r * s;      
        Matrix4x4 TRS = Matrix.convertMatrix4x4(TRSMatrix);

        return TRS;
    }

    public static Matrix4x4 TRSMatrix4x4TRS(Vector4 transform, Vector3 angle, Vector3 scale) {
        Vector3 newPOsition = new Vector3(transform.x, transform.y, transform.z);
        Quaternion newRotation = Quaternion.Euler(angle.x, angle.y, angle.z);
        Matrix4x4 matrix = Matrix4x4.TRS(transform, newRotation, scale);
        return matrix;
    }



    public static Vector4 MultiplicationMatrixComponents(Vector4 a, Vector4 b) {
        float x = a.x * b.x;
        float y = a.y * b.y;
        float z = a.z * b.z;
        float w = a.w * b.w;

        return new Vector4(x, y, z, w);
    }
    public static Matrix MultiplicationMatrixxVector4(Matrix a, Vector4 b) {

        Vector4 x = MultiplicationVector4xVector4(a.X, b);
        Vector4 y = MultiplicationVector4xVector4(a.Y, b);
        Vector4 z = MultiplicationVector4xVector4(a.Z, b);
        Vector4 w = MultiplicationVector4xVector4(a.W, b);

        Matrix c = new Matrix(x, y, z, w);

        return c;
    }


    public static Vector4 MultiplicationVector4xVector4(Vector4 a, Vector4 b) {
        return new Vector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
    }

    public static Vector4 MultiplicationMatrixComponents(Vector4 a, float b) {
        float x = a.x * b;
        float y = a.y * b;
        float z = a.z * b;
        float w = a.w * b;

        return new Vector4(x, y, z, w);
    }

    public static float SumVectorComponent(Vector4 a) {
        float sum = a.x + a.y + a.z + a.w;
        return sum;
    }





 
}
