using CustomMath;
using System.Collections.Generic;
using UnityEditor;


//using System.Numerics;
using UnityEngine;

public class InterpolationDemonstration : MonoBehaviour {


    private Vector3D vectorA = new Vector3D(1, 1, 1);
    private Vector3D vectorB = new Vector3D(2, 2, 2);
    private Vector3D vectorZ = new Vector3D(0, 0, 0);
    private Vector3D vectorA2 = new Vector3D(1, 1, 1);
    private Vector3D vectorB2 = new Vector3D(2, 2, 2);
    private Vector3D vectorZ2 = new Vector3D(0, 0, 0);



    [SerializeField]
    [Range(0f, 1f)]
    private float t = 0.5f;

    [SerializeField]
    private float radius = 0.1f;


    [SerializeField]
    private Vector3 vectorA3 = new Vector3(1, 1, 1);
    [SerializeField]
    private Vector3 vectorB3 = new Vector3(2, 2, 2);
    [SerializeField]
    private Vector3 vectorZ3 = new Vector3(0, 0, 0);

    [SerializeField]
    private Vector3 vectorA23 = new Vector3(1, 1, 1);
    [SerializeField]
    private Vector3 vectorB23 = new Vector3(2, 2, 2);
    [SerializeField]
    private Vector3 vectorZ23 = new Vector3(0, 0, 0);


    [SerializeField]
    private GameObject Cube;
    private GameObject CubeRot;

    [SerializeField]
    private Quaternion quaternionA = new Quaternion(1, 1, 1, 1);
    [SerializeField]
    private Quaternion quaternionB = new Quaternion(2, 2, 2, 2);
    [SerializeField]
    private Quaternion quaternionC = new Quaternion(0, 0, 0, 0);
    [SerializeField]
    private Quaternion quaternion100 = new Quaternion(100, 100, 100, 1);
    [SerializeField]
    private Quaternion quaternionEuler = Quaternion.Euler(0, 0, 90);


    private List<Vector3D> sLerpList = new List<Vector3D>();



    bool demo1 = false;
    [ContextMenu("Linear interpolation")]
    public void LerpDemonstration() {
        demo1 = !demo1;
    }
    public void LerpDemonstrationFunk() {
        if (demo1) {
            vectorZ = Interpolation.Lerp3D(vectorA, vectorB, t);
            vectorZ3 = Vector3D.ConversionVector3DInVector3(vectorZ);
            Debug.Log("3D: " + vectorZ + "\n3:" + vectorZ3.ToString());
        }
    }


    bool demo2 = false;
    [ContextMenu("Remap")]
    public void RemapDemonstration() {
        demo2 = !demo2;
    }
    public void RemapDemonstrationFunk() {
        if (demo2) {
            vectorZ2 = Interpolation.Remap3D(vectorA, vectorB, vectorA2, vectorB2, vectorZ);
            vectorZ23 = Vector3D.ConversionVector3DInVector3(vectorZ2);
            Debug.Log("3D: " + vectorZ2 + "\n3:" + vectorZ23.ToString());
        }
    }

    bool demo3 = false;
    [ContextMenu("Spherical interpolation")]
    public void SlerpDemonstration() {
        demo3 = !demo3;
    }
    public void SlerpDemonstrationFunk() {
        if (demo3) {
            vectorZ = Interpolation.SLerp3D(vectorA, vectorB, t);
            vectorZ3 = Vector3D.ConversionVector3DInVector3(vectorZ);
            Debug.Log("3D: " + vectorZ + "\n3:" + vectorZ3.ToString());
            sLerpList = Interpolation.SLerpList3D(vectorA, vectorB, t);
        }
    }

    bool demo4 = false;
    [ContextMenu("SLerp Quaternion3D")]
    public void SLerpQuaternion() {
        demo4 = !demo4;
        if (demo4) {
            CubeRot = Instantiate(Cube, Vector3.zero, quaternionC);
        }
        else {
            Destroy(Cube);
        }
    }
    public void SLerpQuaternionFunk() {
        if (demo4 && Cube.transform.rotation != null) {
            quaternionC = Interpolation.SLerpQuaternion3D(quaternionA, quaternionB, t);
            CubeRot.transform.rotation *= quaternionC;
            Debug.Log("quaternionC: " + quaternionC.ToString());
        }
    }

    private void Update() {
        vectorA = Vector3D.ConversionVector3InVector3D(vectorA3);
        vectorB = Vector3D.ConversionVector3InVector3D(vectorB3);
        vectorZ = Vector3D.ConversionVector3InVector3D(vectorZ3);

        vectorA2 = Vector3D.ConversionVector3InVector3D(vectorA23);
        vectorB2 = Vector3D.ConversionVector3InVector3D(vectorB23);
        vectorZ2 = Vector3D.ConversionVector3InVector3D(vectorZ23);

        LerpDemonstrationFunk();
        RemapDemonstrationFunk();
        SlerpDemonstrationFunk();
        SLerpQuaternionFunk();
    }


    private void OnDrawGizmosSelected() {
        if (demo1) {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(vectorA3, radius);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(vectorB3, radius);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(vectorZ3, radius);
        }
        if (demo2) {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(vectorA3, radius);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(vectorB3, radius);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(vectorZ3, radius);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(vectorA23, radius);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(vectorB23, radius);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(vectorZ23, radius);
        }

        if (demo3) {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, vectorA3);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, vectorB3);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(vectorZ3, radius);

            foreach (Vector3D vectors in sLerpList) {
                Gizmos.color = Color.grey;
                Gizmos.DrawSphere(Vector3D.ConversionVector3DInVector3(vectors), radius);
            }
        }

    }


}
