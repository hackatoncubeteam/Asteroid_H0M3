using System;
using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Transform = UnityEngine.Transform;

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
        Vector2 worldAimDirection = ((Vector2)(TargetPoint - transform.position)).normalized;
        
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

        var CharArmature = Image.GetComponent<UnityArmatureComponent>().armature;
        CharArmature.flipX = !(_desiredAimRotation.eulerAngles.z < 90 || _desiredAimRotation.eulerAngles.z > 270);

        // aimBone = CharArmature.GetBone("aim_shlang");
        //aimBone. = (_desiredAimRotation * transform.rotation) * OriginAimDirection;
        //WeaponSocket = CharArmature.GetSlot("aim_added1");

        Quaternion interpolatedRotation = Quaternion.Lerp(currentRotation, desiredRotation, AimingSpeed);
        
        Weapon.SetPositionAndRotation(WeaponSocket.position, interpolatedRotation);
    }
}
