using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using Unity.VisualScripting;

public class MatrixDemonstration : MonoBehaviour
{
    [SerializeField]
    private Vector4 translation;
    [SerializeField]
    private Vector3 angleRotation;
    [SerializeField]
    private Vector3 scale;

    private Matrix4x4 _matrixTRS;   

    
    void Update()
    {
        //использую Matrix4x4 для получения нужных значений из матрицы -
        //в самой функции я сначала перемножаю матрицы (в своей структуре),
        //а только потом перевожу свою матрицу в Matrix4x4

        _matrixTRS = MatrixRotation.TRSMatrix4x4(translation, angleRotation, scale);
        Vector4 newPos = _matrixTRS.GetT();
        transform.position = new Vector3(newPos.x, newPos.y, newPos.z);

        Quaternion newRot = _matrixTRS.GetR();
        transform.rotation = newRot;

        Vector4 newScale = _matrixTRS.GetS();
        transform.localScale = new Vector3(newScale.x, newScale.y, newScale.z);
        Debug.Log(_matrixTRS);


    }
    public void TRStest() {
        //использовал для тест матрицы TRS
        _matrixTRS = MatrixRotation.TRSMatrix4x4TRS(translation, angleRotation, scale);
        Vector3 newPos = _matrixTRS.GetPosition();
        transform.position = newPos;
        Quaternion newRot = _matrixTRS.GetR();
        transform.rotation = newRot;
        Vector3 newScale = _matrixTRS.GetS();
        transform.localScale = newScale;
    }

    //проверка умножения матриц
    public void MatrixTest() {
        Vector4 a1 = new Vector4(1, 2, 3, 4);
        Vector4 a2 = new Vector4(1, 2, 3, 4);
        Vector4 a3 = new Vector4(1, 2, 3, 4);
        Vector4 a4 = new Vector4(1, 2, 3, 4);

        Vector4 b1 = new Vector4(1, 2, 3, 4);
        Vector4 b2 = new Vector4(1, 2, 3, 4);
        Vector4 b3 = new Vector4(1, 2, 3, 4);
        Vector4 b4 = new Vector4(1, 2, 3, 4);

        Matrix a = new Matrix(a1, a2, a3, a4);

        Matrix b = new Matrix(b1, b2, b3, b4);

        Matrix c = a * b;
        Debug.Log(c);
    }

}
