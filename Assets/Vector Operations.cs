using CustomMath;
using System.Collections.Generic;
using UnityEditor;
//using System.Numerics;
using UnityEngine;



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

    // private Vector3D vectorScalarProduct = new Vector3D(0, 0, 0);
    private Vector3D vectorCrossProduct = new Vector3D(0, 0, 0);
    private Vector3D vectorLinearTransformations = new Vector3D(0, 0, 0);

    private Vector3D vectorRotation = new Vector3D(10, 0, 10);
    private Vector3D vectorReflectionMirror = new Vector3D(10, 0, 10);
    private Vector3D vectorReflectionGlass = new Vector3D(10, 0, 10);
    private Vector3 vectorNormalSurface = Vector3.up; //Vector3.up(0,1,0),  Vector3.forward(0,0,1)  Vector3.right(1,0,0)

    private Vector3D vectorBallistics = new Vector3D(10, 0, 10);
    private List<Vector3D> vectorBallisticsList = new List<Vector3D>();

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

    [SerializeField]
    private float g = 9.8f;
    [SerializeField]
    private float timeSecond = 10;

    [SerializeField]
    private float angleDeegres = 0;
    [SerializeField]
    private float angleRadians = 0;

    [SerializeField]
    [Range(0f, 1f)]
    private float kElasticity = 1;


    public float angle = 30f;
    public float angleRotation = 2f;




    private bool vivod1 = false;
    private bool vivod2 = false;
    private bool vivod3 = false;
    private bool vivod4 = false;
    private bool vivod5 = false;
    private bool vivod6 = false;
    private bool vivod7 = false;

    [SerializeField]
    private Color color1 = new Color(0.2F, 0.3F, 0.4F, 0.5F);

    [SerializeField]
    private Color color2 = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    [SerializeField]
    private Color color3 = new Color(0.2F, 0.3F, 0.4F, 0.5F);

    [SerializeField]
    private Color color4 = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    [SerializeField]
    private Color color5 = new Color(0.2F, 0.3F, 0.4F, 0.5F);

    [SerializeField]
    private Color color6 = new Color(0.2F, 0.3F, 0.4F, 0.5F);

    [ContextMenu("+-*1")]
    public void Sum_Sub_Scal_Normal()
    {
        vivod1 = !vivod1;
        Sum_Sub_Scal_Normal_Funk(vivod1);
    }
    public void Sum_Sub_Scal_Normal_Funk(bool vivod1)
    {
        if (vivod1)
        {
            Debug.LogError(vectorA);
            Debug.LogError(vectorB);

            vectorSum = Vector3D.Summation(vectorA, vectorB);
            Debug.Log("Сумма векторов(зеленый):" + vectorSum);

            vectorSub = Vector3D.Subtraction(vectorA, vectorB);
            Debug.Log("Разность векторов(желтый):" + vectorSub);

            vectorScaling = Vector3D.Scaling(vectorA, multiplier);
            Debug.Log("Скалярное произведение(color1):" + vectorScaling);

            vectorNormal = Vector3D.Normalized(vectorA);
            Debug.Log("Нормализованный вектоор(color2):" + vectorNormal + "    длина: " + Vector3D.Length(vectorNormal));

        }
    }


    [ContextMenu("*V_CP_LT")]
    public void ScalingV_crospProd_LinerTransform()
    {
        vivod2 = !vivod2;
        ScalingV_crospProd_LinerTransform_funk(vivod2);
    }
    public void ScalingV_crospProd_LinerTransform_funk(bool vivod2)
    {
        if (vivod2)
        {
            Debug.LogError(vectorA);
            Debug.LogError(vectorB);
            Debug.Log("Скалярное произведение(умнож): " + Vector3D.ScalingVector(vectorA, vectorB));

            vectorCrossProduct = Vector3D.CrossProduct(vectorA, vectorB);
            Debug.Log("Перекрестное произведение: " + vectorCrossProduct);

            vectorLinearTransformations = Vector3D.LinearTransformations(vectorNewSpaceI, vectorNewSpaceJ, vectorNewSpaceK, vectorA);
            Debug.Log("Преобразование из пространства в новое пространство\n: " + vectorLinearTransformations.ToString());

        }
    }


    [ContextMenu("Angle")]
    public void AngleBetween()
    {
        vivod3 = !vivod3;
        AngleBetween_funk(vivod3);
    }
    public void AngleBetween_funk(bool vivod3)
    {
        if (vivod3)
        {
            Debug.LogError(vectorA);
            Debug.LogError(vectorB);
            angleDeegres = Vector3D.AngleBetweenVectorsDegrees(vectorA, vectorB);
            angleRadians = Vector3D.AngleBetweenVectorsRadians(vectorA, vectorB);
            Debug.Log("Угол между двумя векторами:   (Градусы): " + angleDeegres + "   (Радианы): " + angleRadians);
        }
    }


    [ContextMenu("Rotation_MOD1")]
    public void Rotation()
    {
        vivod4 = !vivod4;
        Rotation_funk(vivod4);
    }
    public void Rotation_funk(bool vivod3)
    {
        if (vivod4)
        {
            Debug.LogError(vectorA);
            Debug.LogError(vectorB);
            vectorRotation = Vector3D.RotationAroundPointСoordinate(vectorB, vectorRotation, angleRotation / Mathf.Rad2Deg, false, false, true);
            //vectorRotation = Vector3D.RotationAroundPoint(vectorB, vectorRotation, angleRotation / Mathf.Rad2Deg);
            //    vectorRotation = Vector3D.RotationAroundPoint(Vector3D.ConversionVector3InVector3D(Vector3.zero), vectorA, angleRotation / Mathf.Rad2Deg);
            //    vectorA = vectorRotation;
            //xA = vectorRotation.X;
            //yA = vectorRotation.Y;
            //zA = vectorRotation.Z;            
        }
    }


    [ContextMenu("Rotation_MOD2")]
    public void RotationMOD2()
    {
        vivod5 = !vivod5;
        Rotation_funkMOD2(vivod5);
    }
    public void Rotation_funkMOD2(bool vivod3)
    {
        float _timer = Time.deltaTime;

        if (vivod5)
        {
            Vector3D vectorAnew = vectorA;
            while (vectorA.X != vectorAnew.X && vectorA.Y != vectorAnew.Y && vectorA.Z != vectorAnew.Z)
            {
                vectorRotation = Vector3D.RotationAroundPoint(Vector3D.ConversionVector3InVector3D(Vector3.zero), vectorA, angleRotation / Mathf.Rad2Deg);
                vectorA = vectorRotation;
                xA = vectorRotation.X;
                yA = vectorRotation.Y;
                zA = vectorRotation.Z;
                _timer += Time.deltaTime;

            }
        }
    }


    [ContextMenu("Reflection")]
    public void Reflection()
    {
        vivod6 = !vivod6;
        Reflection_funk(vivod6);
    }
    public void Reflection_funk(bool vivod6)
    {
        float _timer = Time.deltaTime;

        if (vivod6)
        {
            vectorReflectionMirror = Vector3D.ReflectionFromThePlaneMirror(vectorA, vectorB, Vector3D.ConversionVector3InVector3D(vectorNormalSurface), kElasticity);
            vectorReflectionGlass = Vector3D.ReflectionFromThePlaneGlass(vectorA, vectorB, Vector3D.ConversionVector3InVector3D(vectorNormalSurface), kElasticity);
            Debug.Log("Координаты отраженного вектора(зеркало) " + vectorReflectionMirror + "  Нормаль:  " + Vector3D.ConversionVector3InVector3D(vectorNormalSurface) + " исходный: " + vectorA);
            Debug.Log("Координаты отраженного вектора(стекло) " + vectorReflectionGlass);
        }
    }

    [ContextMenu("Ballistics")]
    public void Ballistics()
    {
        vivod7 = !vivod7;
        Ballistics_funk(vivod7);
    }
    public void Ballistics_funk(bool vivod7)
    {

        if (vivod7)
        {

            vectorBallisticsList = Vector3D.Ballistics(vectorA, vectorB, angleDeegres * Mathf.Rad2Deg, g, timeSecond);
            Debug.Log("Координаты вектора" + vectorA + "  угол: " + (angleRadians * Mathf.Rad2Deg));
        }
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

    }

    // Update is called once per frame
    void Update()
    {

        vectorA.Set(xA, yA, zA);
        vectorB.Set(xB, yB, zB);

        vectorNewSpaceI.Set(x_NewSpaceI, y_NewSpaceI, z_NewSpaceI);
        vectorNewSpaceJ.Set(x_NewSpaceJ, y_NewSpaceJ, z_NewSpaceJ);
        vectorNewSpaceK.Set(x_NewSpaceK, y_NewSpaceK, z_NewSpaceK);


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorA));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorB));
        Gizmos.color = Color.grey;
        Gizmos.DrawSphere(Vector3D.ConversionVector3DInVector3(vectorRotation), 1f); // синий


        if (vivod1)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorA)); //красный

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorB)); // синий


            Gizmos.color = Color.green;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorSum)); //зеленый

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorSub)); //желтый


            Gizmos.color = color1;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorScaling)); //розовый

            Gizmos.color = color2;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorNormal)); //серебристый

            Sum_Sub_Scal_Normal_Funk(vivod1);



        }

        if (vivod2)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorA)); //красный

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorB)); // синий


            Gizmos.color = Color.green;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorCrossProduct)); //зеленый

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorLinearTransformations)); //желтый


            Gizmos.color = color3;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorNewSpaceI)); //белый

            Gizmos.color = color4;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorNewSpaceI)); //белый

            Gizmos.color = color5;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorNewSpaceK)); //белый

            ScalingV_crospProd_LinerTransform_funk(vivod2);



        }

        if (vivod3)
        {
            bool isEnterTheAngle = angle <= Vector3D.AngleBetweenVectorsDegrees(vectorA, vectorB);
            Gizmos.color = isEnterTheAngle ? Color.red : Color.green;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorA)); //красный

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorB)); // синий

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(Vector3D.CrossProduct(vectorA, vectorB))); // желтый

            AngleBetween_funk(vivod3);


            Handles.DrawWireArc(
  /*центр*/    transform.position,
  /*нормаль*/  Vector3D.ConversionVector3DInVector3(Vector3D.Normalized(Vector3D.CrossProduct(vectorA, vectorB))),
  /*выход*/    Vector3D.ConversionVector3DInVector3(Vector3D.Normalized(vectorA)),
  /*угол*/     Vector3D.AngleBetweenVectorsDegrees(vectorA, vectorB),
  /*радиус*/   Vector3D.Length(Vector3D.Normalized(vectorA)));


            //Handles.DrawSolidDisc(
            //    transform.position,               
            //    Vector3D.ConversionVector3DInVector3(Vector3D.Normalized(Vector3D.CrossProduct(vectorA, vectorB))),
            //    Vector3D.Length(Vector3D.Normalized(Vector3D.CrossProduct(vectorA, vectorB))) );
        }


        if (vivod4)
        {

            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorA)); //красный

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorB)); // синий

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(Vector3D.ConversionVector3DInVector3(vectorB), Vector3D.ConversionVector3DInVector3(vectorRotation)); // синий


            Gizmos.color = Color.grey;
            Gizmos.DrawSphere(Vector3D.ConversionVector3DInVector3(vectorRotation), 1f); // синий

            vivod4 = !vivod4;
        }

        if (vivod5)
        {

            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorA)); //красный

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorB)); // синий

            vivod4 = !vivod4;
        }

        if (vivod6)
        {

            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorA)); //красный

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorB)); // синий


            Gizmos.color = Color.green;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorReflectionMirror)); //
                                                                                                         // 
            Gizmos.color = Color.black;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorReflectionGlass)); // желтый

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(Vector3.zero, vectorNormalSurface * 2); // желтый

            Handles.color = Color.yellow;
            Handles.DrawSolidDisc(
                transform.position,
                vectorNormalSurface,
                1);
            Handles.color = Color.white;

            if (vectorNormalSurface == Vector3.up) //рисую диск плоскости отражения
            {
                Handles.DrawSolidDisc(
                    transform.position,
                    Vector3.right, //Vector3.up(0,1,0),  Vector3.forward(0,0,1)  Vector3.right(1,0,0)
                    1);
            }

            if (vectorNormalSurface == Vector3.forward)
            {
                Handles.DrawSolidDisc(
                    transform.position,
                    Vector3.up,
                    1);
            }

            if (vectorNormalSurface == Vector3.right)
            {
                Handles.DrawSolidDisc(
                    transform.position,
                    Vector3.forward,
                    1);
            }
            
            Reflection_funk(true);
        }

        if (vivod7)
        {

            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorA)); //красный

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, Vector3D.ConversionVector3DInVector3(vectorB)); // синий

            Debug.Log("Количество: " + vectorBallisticsList.Count);
            foreach (Vector3D vectors in vectorBallisticsList)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(Vector3D.ConversionVector3DInVector3(vectors), (float)(vectorBallisticsList.Count / timeSecond)); // синий
            }
            Ballistics_funk(true);
        }


        Update();

    }




}
