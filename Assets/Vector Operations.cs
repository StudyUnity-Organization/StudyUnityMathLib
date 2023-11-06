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
             
    //public class Vector3D {
    //    float x;
    //    float y;
    //    float z;

    //    public Vector3D(float x1, float y1, float z1)
    //    {
    //        x = x1;
    //        y = y1;
    //        z = z1;
    //    }
    //    public void Set(float x1, float y1, float z1)
    //    {
    //        x = x1;
    //        y = y1;
    //        z = z1;
    //    }

    //    public float getX() { 
    //        return x;        
    //    }
    //    public float getY() {
    //        return y;
    //    }
    //    public float getZ() {
    //        return z;
    //    }
    //}

    //public Vector3D SummationVector3D(Vector3D vectorA, Vector3D vectorB)    { //+
    //     Vector3D vectorZ = new Vector3D(vectorA.getX() + vectorB.getX(), vectorA.getY() + vectorB.getY(), vectorA.getZ() + vectorB.getZ());         
    //     return vectorZ;
    //}

    //public Vector3D SubtractionVector3D(Vector3D vectorA, Vector3D vectorB)    { //-
    //    Vector3D vectorZ = new Vector3D(vectorA.getX() - vectorB.getX(), vectorA.getY() - vectorB.getY(), vectorA.getZ() - vectorB.getZ());
    //    return vectorZ;
    //}

    //public Vector3D ScalingVector3D(Vector3D vectorA, float A)    { //*
    //    Vector3D vectorZ = new Vector3D(vectorA.getX()*A, vectorA.getY()*A, vectorA.getZ()*A);
    //    return vectorZ;
    //}

    //public Vector3D CrossProductVector3D(Vector3D vectorA, Vector3D vectorB)
    //{ //-
    //    Vector3D vectorZ = new Vector3D(vectorA.getY() * vectorB.getZ() - vectorA.getZ() * vectorB.getY(),      // (a.y*b.z - a.z*b.y)
    //                                    vectorA.getX() * vectorB.getZ() - vectorA.getZ() * vectorB.getX(),      // (a.x*b.z - a.z*b.x)
    //                                    vectorA.getX() * vectorB.getY() - vectorA.getY() * vectorB.getX()  );   // (a.x*b.y - a.y*b.x)

    //    return vectorZ;
    //}

    //public float ScalingVector3Dcomposition(Vector3D vectorA, Vector3D vectorB) //ax × bx + ay * by + az * bz /// нужно для определения параллельности или перпендиккулярности 
    //{ //*       
    //    float compositionVectors = vectorA.getX() * vectorB.getX() + vectorA.getY() * vectorB.getY() + vectorA.getZ() * vectorB.getZ();
    //    float scalingVecotor = compositionVectors;
    //    return scalingVecotor;
    //}

    //public float ScalingVector3Dcos(Vector3D vectorA, Vector3D vectorB) //|a| × |b| × cos(θ)
    //{ //*       
    //    float scalingVecotor = LengthVector3D(vectorA) * LengthVector3D(vectorB) * CosVector3D(vectorA, vectorB);
    //    return scalingVecotor;
    //}

    //public float CosVector3D(Vector3D vectorA, Vector3D vectorB) // cos(θ) = (ax × bx + ay * by + az * bz) / |a| × |b|
    //{ //*
    //    float compositionVectors = vectorA.getX() * vectorB.getX() + vectorA.getY() * vectorB.getY() + vectorA.getZ() * vectorB.getZ();
    //    float cosin = compositionVectors / (LengthVector3D(vectorA) * LengthVector3D(vectorB));
    //    return cosin;
    //}


    //public Vector3D NormalizedVector3D(Vector3D vector)
    //{ //*
    //    float lengthVector = LengthVector3D(vector);
    //    Vector3D vectorNormalized = new Vector3D(vector.getX() / lengthVector, vector.getY() / lengthVector, vector.getZ() / lengthVector);
    //    return vectorNormalized;
    //}

    //public Vector3D LinearTransformationsVector3D(Vector3D vectorNormal_i, Vector3D vectorNormal_j, Vector3D vectorNormal_z, Vector3D vector)
    //{ //*        
    //    Vector3D vectorNewSpace = new Vector3D(vector.getX() * vectorNormal_i.getX() + vector.getY() * vectorNormal_j.getX() + vector.getZ() * vectorNormal_z.getX(),
    //                                           vector.getX() * vectorNormal_i.getY() + vector.getY() * vectorNormal_j.getY() + vector.getZ() * vectorNormal_z.getY(),
    //                                           vector.getX() * vectorNormal_i.getZ() + vector.getY() * vectorNormal_j.getZ() + vector.getZ() * vectorNormal_z.getZ());
    //    return vectorNewSpace;
    //}



    //public float LengthVector3D(Vector3D vector)  { //*       
    //    float lengthVector = Mathf.Sqrt(vector.getX()* vector.getX() + vector.getY()* vector.getY() + vector.getZ()* vector.getZ());
    //    return lengthVector;
    //}


    //public void OutputVector3D(Vector3D vector)    {
    //    Debug.Log("Координаты вектора: " + vector.getX().ToString() + ' ' + vector.getY().ToString() + ' ' + vector.getZ().ToString() + '\n');
    //}
    //public string OutputStringVector3D(Vector3D vector)    {
    //    return "Координаты вектора: " + vector.getX().ToString() + ' ' + vector.getY().ToString() + ' ' + vector.getZ().ToString() + '\n';
    //}








}
 