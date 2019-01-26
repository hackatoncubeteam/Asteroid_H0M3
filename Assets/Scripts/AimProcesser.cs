using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimProcesser : MonoBehaviour
{

    [SerializeField] Transform pivotPoint;



    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(pivotPoint.position, 1f);
    }


    void SetAimAngle(Quaternion rotator)
    {
        //transform.Rotate(rotator.eulerAngles * Time.deltaTime);
        transform.rotation = Quaternion.Euler(rotator.eulerAngles * Time.deltaTime);
    }


    void SetWorldPivotPointPosition(Vector3 Position)
    {
        transform.position = Position;
        pivotPoint.position = Position;
    }
}
