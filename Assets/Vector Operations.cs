using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using CustomMath;
using Unity.VisualScripting;

public class Vector : MonoBehaviour
{
    [SerializeField]
    private float xA = 1;
    [SerializeField]
    private float yA = 2;
    [SerializeField]
    private float zA = 3;
    [SerializeField]
    private float xB = 2;
    [SerializeField]
    private float yB = 3;
    [SerializeField]
    private float zB = 4;

    [SerializeField]
    private float multiplier = 10;

    private Vector3D vectorA = new Vector3D(1, 1, 1);
    private Vector3D vectorB = new Vector3D(2, 2, 2);
    private Vector3D vectorZ = new Vector3D(0, 0, 0);

    private Vector3D vectorNewSpaceI = new Vector3D(1, 1, 1);
    private Vector3D vectorNewSpaceJ = new Vector3D(1, 1, 1);
    private Vector3D vectorNewSpaceK = new Vector3D(1, 1, 1);


    private Vector3D vectorSum = new Vector3D(0, 0, 0);
    private Vector3D vectorSub = new Vector3D(0, 0, 0);
    private Vector3D vectorScaling = new Vector3D(0, 0, 0);
    private Vector3D vectorNormal = new Vector3D(0, 0, 0);


    [SerializeField]
    private float x_NewSpaceI = 1;
    [SerializeField]
    private float y_NewSpaceI = 1;
    [SerializeField]
    private float z_NewSpaceI = 1;

    [SerializeField]
    private float x_NewSpaceJ = 1;
    [SerializeField]
    private float y_NewSpaceJ = 1;
    [SerializeField]
    private float z_NewSpaceJ = 1;

    [SerializeField]
    private float x_NewSpaceK = 1;
    [SerializeField]
    private float y_NewSpaceK = 1;
    [SerializeField]
    private float z_NewSpaceK = 1;

    private LineRenderer lineVectorA;
    private LineRenderer lineVectorB;

    private bool vivod1 = false;

    [ContextMenu("+-*1")]
    public void Sum_Sub_Scal_Normal()
    {
        Debug.LogError(vectorA);
        Debug.LogError(vectorB);

        vectorSum = Vector3D.Summation(vectorA, vectorB);
        Debug.Log("Сумма векторов:" + vectorSum);

        vectorSub = Vector3D.Subtraction(vectorA, vectorB);
        Debug.Log("Разность векторов:" + vectorSub);

        vectorScaling = Vector3D.Scaling(vectorA, multiplier);
        Debug.Log("Скалярное произведение:" + vectorScaling);

        vectorNormal = Vector3D.Normalized(vectorA);
        Debug.Log("Нормализованный вектоор:" + vectorNormal + "    длина: " + Vector3D.Length(vectorNormal));

        vivod1 = !vivod1;
    }

    [ContextMenu("*V_CP_LT")]
    public void ScalingV_crospProd_LinerTransform()
    {
        Debug.LogError(vectorA);
        Debug.LogError(vectorB);
        Debug.Log("Скалярное произведение(умнож): " + Vector3D.ScalingVector(vectorA, vectorB));

        Debug.Log("Перекрестное произведение: " + Vector3D.CrossProduct(vectorA, vectorB));

        Debug.Log("Преобразование из пространства в новое пространство\n: " + Vector3D.LinearTransformations(vectorNewSpaceI, vectorNewSpaceJ, vectorNewSpaceK, vectorA).ToString());
    }

    [ContextMenu("Angle")]
    public void AngleBetween()
    {
        Debug.LogError(vectorA);
        Debug.LogError(vectorB);
        float angleDeegres = Vector3D.AngleBetweenVectorsDegrees(vectorA, vectorB);
        float angleRadians = Vector3D.AngleBetweenVectorsRadians(vectorA, vectorB);
        Debug.Log("Угол между двумя векторами:   (Градусы): " + angleDeegres + "   (Радианы): " + angleRadians);   
    }
    [ContextMenu("Initial Values")]
    public void InitialVsalues()
    {
        //xA = 10;
        //yA = 0;
        //zA = 0;
        //

        xA = 4;
        yA = 8;
        zA = 10;

        xB = 9;
        yB = 2;
        zB = 7;
    }


    // Start is called before the first frame update
    void Start()
    {
        Line();
    }

    // Update is called once per frame
    void Update()
    {

        vectorA.Set(xA, yA, zA);
        vectorB.Set(xB, yB, zB);

        vectorNewSpaceI.Set(x_NewSpaceI, y_NewSpaceI, z_NewSpaceI);
        vectorNewSpaceJ.Set(x_NewSpaceJ, y_NewSpaceJ, z_NewSpaceJ);
        vectorNewSpaceK.Set(x_NewSpaceK, y_NewSpaceK, z_NewSpaceK);

        DrawLine();
    }

    private void Line() { 
        lineVectorA = GetComponent<LineRenderer>();
        lineVectorB = GetComponent<LineRenderer>();

    }

    private void DrawLine()
    {
        //Vector3 vector3 = new Vector3(1,1,1);
        //vector3
        //lineVectorA.SetPosition();
        //lineVectorB = GetComponent<LineRenderer>();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorA));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorB));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorZ));

        if (vivod1)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorA)); //красный

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorB)); //желтый


            Gizmos.color = Color.green;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorSum)); //зеленый

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorSub)); //синий


            Gizmos.color = Color.HSVToRGB(255, 0, 255);
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorScaling)); //розовый

            Gizmos.color = Color.HSVToRGB(191, 191, 191);
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorNormal)); //серебристый

            Update();

        }

        //Vector3 vector3 = new Vector3(1,1,1);
        //vector3
        //lineVectorA.SetPosition();
        //lineVectorB = GetComponent<LineRenderer>();

    }


}
 