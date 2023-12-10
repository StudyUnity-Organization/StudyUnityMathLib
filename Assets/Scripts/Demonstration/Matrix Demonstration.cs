using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;

public class MatrixDemonstration : MonoBehaviour
{


    public Vector4 translation;
    public Vector3 angleRotation;
    public Vector3 scale;

    private Vector4 TRS;

    private Vector3 _startPosition; 
    private Vector4 _rotation;
    private Vector4 _scaling;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = MatrixRotation.TranslationMatrix(_startPosition, translation);

        _rotation = MatrixRotation.RotationMatrix(transform.position, angleRotation);

        transform.position = new Vector3(_rotation.x, _rotation.y, _rotation.z);

        _scaling = MatrixRotation.ScaleMatrix(transform.position, scale);

        transform.position = new Vector3(_scaling.x, _scaling.y, _scaling.z);


        //TRS = MatrixRotation.TRS(_startPosition, translation, angleRotation, scale);
        //transform.position = new Vector3(TRS.x, TRS.y, TRS.z);
    }
}
