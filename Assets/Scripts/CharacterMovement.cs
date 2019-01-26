using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    private Vector3 _accumulatedForce = new Vector3();
    private Vector3 _accumulatedImpulse = new Vector3();
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField]
    private float InputForce = 10.0f;
    
    [SerializeField]
    private float JumpImpulse = 100.0f;
    
    [SerializeField]
    private float MaxInputVelocity = 10.0f;

    private bool _canJump = true;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void AddMovementInput(Vector3 movementInput)
    {
        _accumulatedForce += movementInput * InputForce;
    }

    public void Jump()
    {
        Collider2D collider = _rigidbody2D.GetComponent<Collider2D>();
        Collider2D[] contacts = new Collider2D[0];
        if (_canJump)
        {
            _accumulatedImpulse += Vector3.up * JumpImpulse;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = ComplexMassController.GetRotatorForLocation(transform.position);
        
        float InputProjectionOnVelocity = Vector3.Dot(_accumulatedForce.normalized, _rigidbody2D.velocity);
        
        if (InputProjectionOnVelocity < MaxInputVelocity)
        {
            _rigidbody2D.AddRelativeForce(_accumulatedForce, ForceMode2D.Force);
        }

        _rigidbody2D.AddRelativeForce(_accumulatedImpulse, ForceMode2D.Impulse);
        
        _accumulatedForce = new Vector3();
        _accumulatedImpulse = new Vector3();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _canJump = true;
        print("Can jump");
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _canJump = false;
        print("Cannot jump");
    }
}
