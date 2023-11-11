using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
<<<<<<< HEAD
=======

namespace CustomMath
{

    public struct Vector3D
    {  //для проверки гита х2
>>>>>>> b0236417 (Added conversion from Vector3 to Vector3D and back + Gizmos)

        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public Vector3D(float x1, float y1, float z1)
        {
            X = x1;
            Y = y1;
            Z = z1;
        }

        public void Set(float x1, float y1, float z1)
        {
            X = x1;
            Y = y1;
            Z = z1;
        }

        public static Vector3D Summation(Vector3D vectorA, Vector3D vectorB)
        {   //сложение векторов
            Vector3D vectorZ = new Vector3D(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y, vectorA.Z + vectorB.Z);
            return vectorZ;
        }
        public static Vector3D Subtraction(Vector3D vectorA, Vector3D vectorB)
        {  //вычитание векторов
            Vector3D vectorZ = new Vector3D(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y, vectorA.Z - vectorB.Z);
            return vectorZ;
        }

        public static Vector3D Scaling(Vector3D vectorA, float A)
        { //умножение вектора на скаляр  
            Vector3D vectorZ = new Vector3D(vectorA.X * A, vectorA.Y * A, vectorA.Z * A);
            return vectorZ;
        }


        public static Vector3D Normalized(Vector3D vector)
        { //нормализация
            float lengthVector = Length(vector);
            Vector3D vectorNormalized = new Vector3D(vector.X / lengthVector, vector.Y / lengthVector, vector.Z / lengthVector);
            return vectorNormalized;
        }

        public static Vector3D CrossProduct(Vector3D vectorA, Vector3D vectorB)
        { //векторное произведение - позвояет найти вектор перпендикулярный двум другим векторам(плоскости)
            Vector3D vectorZ = new Vector3D(vectorA.Y * vectorB.Z - vectorA.Z * vectorB.X,      // (a.y*b.z - a.z*b.y)
                                            vectorA.Y * vectorB.Z - vectorA.Z * vectorB.X,      // (a.x*b.z - a.z*b.x)
                                            vectorA.Y * vectorB.Y - vectorA.Y * vectorB.X);   // (a.x*b.y - a.y*b.x)
            return vectorZ;
        }

        public static Vector3D LinearTransformations(Vector3D vectorNormalI, Vector3D vectorNormalJ, Vector3D vectorNormalK, Vector3D vector)
        { //перевод вектора из мирового пространства в локальное        
            Vector3D vectorNewSpace = new Vector3D(vector.X * vectorNormalI.X + vector.Y * vectorNormalJ.X + vector.Z * vectorNormalK.X,
                                                   vector.X * vectorNormalI.Y + vector.Y * vectorNormalJ.Y + vector.Z * vectorNormalK.Y,
                                                   vector.X * vectorNormalI.Z + vector.Y * vectorNormalJ.Z + vector.Z * vectorNormalK.Z);
            return vectorNewSpace;
        }

<<<<<<< HEAD
        public static float ScalingVector(Vector3D vectorA, Vector3D vectorB) { //скалярное умножение двух векторов     //ax × bx + ay * by + az * bz /// нужно для определения параллельности или перпендиккулярности 
=======
        public static float ScalingVector(Vector3D vectorA, Vector3D vectorB)
        { //скалярное умножение двух векторов     //ax × bx + ay * by + az * bz /// нужно для определения параллельности или перпендиккулярности 
>>>>>>> b0236417 (Added conversion from Vector3 to Vector3D and back + Gizmos)
            float scalingVecotor = vectorA.X * vectorB.X + vectorA.Y * vectorB.Y + vectorA.Z * vectorB.Z;
            return scalingVecotor;
        }
        /*
        public static float ScalingVector3Dcos(Vector3D vectorA, Vector3D vectorB) { //скалярное умножение через косинус - не нужно   //|a| × |b| × cos(θ)    
            float scalingVecotor = Length(vectorA) * Length(vectorB) * CosVector3D(vectorA, vectorB);
            return scalingVecotor;
        }
        */

        public static float CosVector3D(Vector3D vectorA, Vector3D vectorB)
        { //косинус между векторами      // cos(θ) = (ax × bx + ay * by + az * bz) / |a| × |b|
            float cosin = ScalingVector(vectorA, vectorB) / (Length(vectorA) * Length(vectorB));
            return cosin;
        }

        public static float AngleBetweenVectorsDegrees(Vector3D vectorA, Vector3D vectorB)
        {
            return Mathf.Acos(CosVector3D(vectorA, vectorB)) * Mathf.Rad2Deg;
        }

        public static float AngleBetweenVectorsRadians(Vector3D vectorA, Vector3D vectorB)
        {
            return Mathf.Acos(CosVector3D(vectorA, vectorB));
        }

<<<<<<< HEAD
        public static float Length(Vector3D vector) { // длина  вектора     
=======
        public static float Length(Vector3D vector)
        { // длина  вектора     
>>>>>>> b0236417 (Added conversion from Vector3 to Vector3D and back + Gizmos)
            float lengthVector = Mathf.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z);
            return lengthVector;
        }

        public override string ToString()
        {
            return $"{X} {Y} {Z}\n";
        }

        public static Vector3 ConversionVector3DInVector3(Vector3D vector3D) {
            Vector3 Vector3new = new Vector3(vector3D.X, vector3D.Y, vector3D.Z);
            return Vector3new;
        }

        public static Vector3D ConversionVector3InVector3D(Vector3 vector3)
        {
            Vector3D Vector3Dnew = new Vector3D(vector3.x, vector3.y, vector3.z);
            return Vector3Dnew;
        }



    }




}
