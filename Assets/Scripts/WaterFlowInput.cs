using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaterFlowController))]
public class WaterFlowInput : MonoBehaviour
{
    [SerializeField]
    private string InputAxisName = "Fire1";

    private bool _isPressed = false;

    private WaterFlowController _waterFlowController;
    
    // Start is called before the first frame update
    void Awake()
    {
        _waterFlowController = GetComponent<WaterFlowController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(InputAxisName) > 0 == _isPressed)
        {
            return;
        }

        _isPressed = Input.GetAxis(InputAxisName) > 0;

        _waterFlowController.SetState(_isPressed);
    }
}
