using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocationController : MonoBehaviour
{
    [SerializeField]
    private CharacterMovement TargetCharacter;
    
    [SerializeField]
    private ComplexMassController TargetCenterOfMass;
    
    [SerializeField]
    private Vector3 Offset = Vector3.back * 100;
    
    [SerializeField]
    private float Character_MoonScreenLineSize = 0.3f;
    
    [SerializeField]
    private float CameraMoveSpeed = 0.3f;
    
    [SerializeField]
    private float CameraRotationSpeed = 0.3f;
    
    [SerializeField]
    private float CameraZoomSpeed = 0.3f;

    private Camera _camera;
    
    // Start is called before the first frame update
    void Awake()
    {
        _camera = GetComponent<Camera>();
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

        Vector3 desiredLocation = (Vector3)TargetCenterOfMass.GetCenterOfMass() + Offset;
        transform.position = Vector3.Lerp(transform.position, desiredLocation, CameraMoveSpeed * Time.deltaTime);
        Vector2 vectorOnTarget = TargetCharacter.transform.position - transform.position;

        float desiredSize = vectorOnTarget.magnitude / Character_MoonScreenLineSize / 2;
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, desiredSize, CameraZoomSpeed * Time.deltaTime);

        float desiredRotation = Quaternion.FromToRotation(Vector2.up, vectorOnTarget.normalized).eulerAngles.z;
        
        float yaw = Mathf.LerpAngle(transform.rotation.eulerAngles.z, desiredRotation, CameraRotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, yaw);
        
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
