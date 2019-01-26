using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotPoint : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.parent.position, 0.1f);
    }
}
