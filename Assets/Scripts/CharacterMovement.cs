using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    private Vector3 _accumulatedForce = new Vector3();
    private Vector3 _accumulatedWorldForce = new Vector3();
    private Vector3 _accumulatedImpulse = new Vector3();
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField]
    private float InputForce = 10.0f;
    
    [SerializeField]
    private float JumpImpulse = 100.0f;
    
    [SerializeField]
    private float MaxInputVelocity = 10.0f;
    
    [SerializeField]
    private float StandingHeight = 1.0f;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void AddMovementInput(Vector3 movementInput)
    {
        AddMovementForce(movementInput * InputForce);
    }

    public void AddMovementForce(Vector3 movementForce)
    {
        _accumulatedForce += movementForce;
    }

    public void AddWorldForce(Vector3 worldForce)
    {
        _accumulatedWorldForce += worldForce;
    }

    public bool CanJump()
    {
        Vector3 down = ComplexMassController.GetRotatorForLocation(transform.position) * Vector3.down;
        var hit = Physics2D.Raycast(transform.position, down, StandingHeight, LayerMask.GetMask("Moon", "Asteroid"));

        return hit;
    }

    public void Jump()
    {
        if (CanJump())
        {
            _accumulatedImpulse += Vector3.up * JumpImpulse;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = ComplexMassController.GetRotatorForLocation(transform.position);
        
        float InputProjectionOnVelocity = Vector3.Dot(_accumulatedForce.normalized, _rigidbody2D.velocity);
        
        if (InputProjectionOnVelocity < MaxInputVelocity)
        {
            _rigidbody2D.AddRelativeForce(_accumulatedForce * Time.deltaTime, ForceMode2D.Force);
        }
        
        _rigidbody2D.AddForce(_accumulatedWorldForce * Time.deltaTime, ForceMode2D.Force);

        _rigidbody2D.AddRelativeForce(_accumulatedImpulse, ForceMode2D.Impulse);
        
        _accumulatedForce = new Vector3();
        _accumulatedWorldForce = new Vector3();
        _accumulatedImpulse = new Vector3();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        
        Vector3 down = ComplexMassController.GetRotatorForLocation(transform.position) * Vector3.down;
        
        Gizmos.DrawRay(transform.position, down * StandingHeight);
    }
}
