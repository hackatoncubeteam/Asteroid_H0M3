using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] 
    private Vector3 OriginAimDirection = Vector3.right;

    [SerializeField]
    private GameObject Weapon;

    private Quaternion _aimRotation = Quaternion.identity;
    
    public void AimToPoint(Vector3 TargetPoint)
    {
        var worldAimDirection = transform.position - TargetPoint;
        var localAimDirection = ComplexMassController.GetRotatorForLocation(transform.position) * worldAimDirection;
        
        _aimRotation = Quaternion.FromToRotation(OriginAimDirection, localAimDirection);
    }

    public Quaternion GetAimRotation()
    {
        return _aimRotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, _aimRotation * transform.rotation * OriginAimDirection);
    }
}
