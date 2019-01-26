using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AimController))]
public class AimInput : MonoBehaviour
{
    private AimController _aimController;
    private Camera _camera;
    
    private void Awake()
    {
        _aimController = GetComponent<AimController>();
        _camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aimPoint = _camera.ScreenToWorldPoint(Input.mousePosition);

        _aimController.AimToPoint(aimPoint);
    }
}
