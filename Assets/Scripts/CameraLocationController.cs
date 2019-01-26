using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class CameraLocationController : MonoBehaviour
{
    [SerializeField]
    private CharacterMovement TargetCharacter;
    
    [SerializeField]
    private ComplexMassController TargetCenterOfMass;
    
    [SerializeField]
    private Vector3 Offset = Vector3.back * 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTargertCharacter();
        UpdateTargetCenterOfMass();
        
        if (TargetCharacter == null ||  TargetCenterOfMass == null)
        {
            return;
        }

        transform.position = (Vector3)TargetCenterOfMass.GetCenterOfMass() + Offset;
        Vector3 VectorOnTarget = TargetCharacter.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, VectorOnTarget.normalized);
        
    }

    void UpdateTargertCharacter()
    {
        if (TargetCharacter == null)
        {
            TargetCharacter = FindObjectOfType<CharacterMovement>();
        }
    }

    void UpdateTargetCenterOfMass()
    {
        if (TargetCenterOfMass == null)
        {
            TargetCenterOfMass = FindObjectOfType<ComplexMassController>();
        }
    }
}
