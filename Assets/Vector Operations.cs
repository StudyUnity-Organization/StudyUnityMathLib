using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using CustomMath;


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
    private Vector3D vectorZ = new Vector3D(0,0,0);

    private Vector3D vectorNewSpaceI = new Vector3D(1, 1, 1);
    private Vector3D vectorNewSpaceJ = new Vector3D(1, 1, 1);
    private Vector3D vectorNewSpaceK = new Vector3D(1, 1, 1);


    [SerializeField]
    private bool vivod1 = false;
    [SerializeField] 
    private bool vivod2 = false;


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




    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    { 
        vectorA.Set(xA, yA, zA);
        vectorB.Set(xB, yB, zB);

        vectorNewSpaceI.Set(x_NewSpaceI, y_NewSpaceI, z_NewSpaceI);
        vectorNewSpaceJ.Set(x_NewSpaceJ, y_NewSpaceJ, z_NewSpaceJ);
        vectorNewSpaceK.Set(x_NewSpaceK, y_NewSpaceK, z_NewSpaceK);


        if (vivod1) {   
            Debug.LogError(vectorA.ToString());
            Debug.LogError(vectorB);  
            vectorZ = Vector3D.Summation(vectorA, vectorB); Debug.Log("Сумма векторов:" + vectorZ);
            vectorZ = Vector3D.Subtraction(vectorA, vectorB); Debug.Log("Разность векторов:" + vectorZ);
            vectorZ = Vector3D.Scaling(vectorA, multiplier); Debug.Log("Скалярное произведение:" + vectorZ);
            vectorZ = Vector3D.Normalized(vectorA); Debug.Log("Нормализованный вектоор:" + vectorZ + "    длина: " + Vector3D.Length(vectorZ));
  
            vivod1 = false;
        }


        if (vivod2)
        {
            Debug.LogError(vectorA);
            Debug.LogError(vectorB);
            Debug.Log("Скалярное произведение(умнож): " + Vector3D.ScalingVector(vectorA, vectorB));
      
            Debug.Log("Перекрестное произведение: " + Vector3D.CrossProduct(vectorA, vectorB));
           
            Debug.Log("Преобразование из пространства в новое пространство\n: " + Vector3D.LinearTransformations(vectorNewSpaceI, vectorNewSpaceJ, vectorNewSpaceK, vectorA).ToString());           


            vivod2 = false;
        }

    }          
    


}
 