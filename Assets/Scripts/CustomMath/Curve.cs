using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[ExecuteAlways]
public class Curve : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    public GameObject pointCteat;
    public GameObject cube;



    [SerializeField]
    private Transform p0;
    [SerializeField]
    private Transform p1;
    [SerializeField]
    private Transform p2;
    [SerializeField]
    private Transform p3;


    [SerializeField]
    [Range(0f, 1f)]
    private float t;

    private Vector3 _pointDemonstration;
    private Vector3 _pointDemonstration1;

    private List<Transform> _newp = new List<Transform>();

    // Update is called once per frame
    void Start() {
        _newp.Add(p0);
        _newp.Add(p1);
        _newp.Add(p2);
        _newp.Add(p3);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0)) {           
        //    Instantiate(pointCteat, Input.mousePosition, Quaternion.identity);
        //}
        //Debug.Log(Input.mousePosition);
      
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); ///?????????????????????????????????

            RaycastHit placeInfo;
            if (Physics.Raycast(ray, out placeInfo)) {               
                    Instantiate(pointCteat, new Vector3(placeInfo.point.x, transform.position.y, placeInfo.point.z), Quaternion.identity);                 
                
            }
            Debug.Log(ray);
        }


        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out hit)) {

        //    if (Input.GetKeyUp(KeyCode.Mouse0)) {
        //        GameObject obj = Instantiate(pointCteat, new Vector3(hit.point.x, hit.point.y, 0), Quaternion.identity);

        //    }

        //}


        //transform.position = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, t);
        cube.transform.position = Bezier.BezierCurveDrawLine(t, _newp);
    }

    private void OnDrawGizmos() {
        _pointDemonstration = Bezier.BezierCurve(0.1f, _newp); ;
        Gizmos.color = Color.red;
        for (float i = 0.1f; i <= 1.1f; i += 0.1f) {
            _pointDemonstration1 = Bezier.BezierCurve(i, _newp); ;
            Gizmos.DrawLine(_pointDemonstration, _pointDemonstration1);
            _pointDemonstration = _pointDemonstration1;
        }

    }


}
