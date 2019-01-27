using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class AimController : MonoBehaviour
{
    [SerializeField] 
    private Vector3 OriginAimDirection = Vector3.right;

    [SerializeField]
    private Transform Weapon;
    
    [SerializeField]
    private Transform WeaponSocket;
    
    [SerializeField]
    private float AimingSpeed = 0.3f;

    [SerializeField]
    private GameObject Image;
    
    private Quaternion _desiredAimRotation = Quaternion.identity;
    
    public void AimToPoint(Vector3 TargetPoint)
    {
        Vector2 worldAimDirection = ((Vector2)(TargetPoint - WeaponSocket.transform.position)).normalized;
        
        Vector2 localAimDirection = Quaternion.Inverse(transform.rotation) * worldAimDirection;
        
        _desiredAimRotation = Quaternion.FromToRotation(OriginAimDirection, localAimDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(WeaponSocket.position, (_desiredAimRotation * transform.rotation) * OriginAimDirection);
    }

    public void Update()
    {
        Quaternion currentRotation = Weapon.rotation;
        Quaternion desiredRotation = _desiredAimRotation * transform.rotation;

        Image.GetComponent<SpriteRenderer>().flipX = !(_desiredAimRotation.eulerAngles.z < 90 || _desiredAimRotation.eulerAngles.z > 270);

        Quaternion interpolatedRotation = Quaternion.Lerp(currentRotation, desiredRotation, AimingSpeed);
        
        Weapon.SetPositionAndRotation(WeaponSocket.position, interpolatedRotation);
    }
}
