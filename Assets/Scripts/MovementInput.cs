using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class MovementInput : MonoBehaviour
{
    private CharacterMovement CharacterMovement;

    [SerializeField] 
    private string MovementInputAxis = "Horizontal";
    
    [SerializeField] 
    private string JumpInputAxis = "Vertical";
    
    // Start is called before the first frame update
    void Awake()
    {
        CharacterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement.AddMovementInput(Vector3.right * Input.GetAxis(MovementInputAxis));
        if (Input.GetAxis(JumpInputAxis) > 0)
        {
            CharacterMovement.Jump();
        }
    }
}
