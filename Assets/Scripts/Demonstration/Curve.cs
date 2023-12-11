using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

[ExecuteAlways]
public class Curve : MonoBehaviour {


    [SerializeField]
    private GameObject pointCreate;
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private GameObject points;


    [SerializeField]
    private Transform p0;
    [SerializeField]
    private Transform p1;
    [SerializeField]
    private Transform p2;
    [SerializeField]
    private Transform p3;

    [SerializeField]
    private bool flagBezierTrueСatmullRomFale = true;

    private GameObject _p;

    //[SerializeField]
    //private Transform p3;


    [SerializeField]
    [Range(0f, 1f)]
    private float t;

    private Vector3 _pointDemonstrationBegin;
    private Vector3 _pointDemonstrationEnd;

    private List<Transform> _pointsCurve = new List<Transform>();

    Ray _ray;
    RaycastHit _hit;
    RaycastHit _placeInfoTransformPoint;
    RaycastHit _placeInfoCreatePoint;

    // Update is called once per frame
    void Start() {
        _pointsCurve.Add(p0);
        _pointsCurve.Add(p1);
        _pointsCurve.Add(p2);
        _pointsCurve.Add(p3);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit)) {   
                if (_hit.transform.parent.name == "Points") {                 
                    if (Physics.Raycast(_ray, out _placeInfoTransformPoint)) {
                        Vector3 mousePosition = new Vector3(_placeInfoTransformPoint.point.x, _placeInfoTransformPoint.point.y, 0);
                        _hit.transform.position = mousePosition;
                        //Debug.Log("Нажал на точку");
                    }
                }          

            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _placeInfoCreatePoint)) {
                _p = Instantiate(pointCreate, new Vector3(_placeInfoCreatePoint.point.x, _placeInfoCreatePoint.point.y, 0), Quaternion.identity);
                _p.transform.parent = points.transform;
                _pointsCurve.Add(_p.transform);
                //Debug.Log(_ray);

            }

        }
        if (flagBezierTrueСatmullRomFale) {
            cube.transform.position = Bezier.BezierCurve(t, _pointsCurve);
        } else {
            cube.transform.position = СatmullRom.СatmullRomSpline(t, _pointsCurve);
        }

    }

        private void OnDrawGizmos() {
        if (flagBezierTrueСatmullRomFale) {
            _pointDemonstrationBegin = Bezier.BezierCurve(0f, _pointsCurve);
        } else {
            _pointDemonstrationBegin = СatmullRom.СatmullRomSpline(0f, _pointsCurve);
        }
      
        Gizmos.color = Color.red;
        if (flagBezierTrueСatmullRomFale) {
            for (float i = 0f; i <= 1f; i += 0.3f / _pointsCurve.Count) {
                _pointDemonstrationEnd = Bezier.BezierCurve(i, _pointsCurve); ;
                Gizmos.DrawLine(_pointDemonstrationBegin, _pointDemonstrationEnd);
                _pointDemonstrationBegin = _pointDemonstrationEnd;
            }

            _pointDemonstrationEnd = Bezier.BezierCurve(1, _pointsCurve); ;
            Gizmos.DrawLine(_pointDemonstrationBegin, _pointDemonstrationEnd);
        } else {
            for (float i = 0f; i <= 1f; i += 0.3f / _pointsCurve.Count) {
                _pointDemonstrationEnd = СatmullRom.СatmullRomSpline(i, _pointsCurve); ;
                Gizmos.DrawLine(_pointDemonstrationBegin, _pointDemonstrationEnd);
                _pointDemonstrationBegin = _pointDemonstrationEnd;
            }

            _pointDemonstrationEnd = СatmullRom.СatmullRomSpline(1, _pointsCurve); ;
            Gizmos.DrawLine(_pointDemonstrationBegin, _pointDemonstrationEnd);
        }

    }


}
