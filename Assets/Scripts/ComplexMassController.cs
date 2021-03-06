﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexMassController : MonoBehaviour
{
    private static ComplexMassController WorldComplexMassController;
    
    [SerializeField]
    private PointEffector2D GravityCenter;
    
    [SerializeField]
    private float GravityForceFactor = -0.03f;

    public static Quaternion GetRotatorForLocation(Vector3 Location)
    {
        if (WorldComplexMassController == null)
        {
            return Quaternion.identity;
        }
        
        Vector3 VectorOnLocation = Location - (Vector3)WorldComplexMassController.GetCenterOfMass();
        return Quaternion.LookRotation(Vector3.forward, VectorOnLocation.normalized);
    }

    private void Awake()
    {
        WorldComplexMassController = this;
    }

    public Rigidbody2D[] GetAllIncludedBodies()
    {
        return GetComponentsInChildren<Rigidbody2D>();
    }

    public Vector2 GetCenterOfMass()
    {
        Vector2 OutCenterOfMass = new Vector2();
        float Mass = 0;
        
        foreach (Rigidbody2D Body in GetAllIncludedBodies())
        {
            OutCenterOfMass = OutCenterOfMass * Mass + Body.worldCenterOfMass * Body.mass;
            
            Mass += Body.mass;

            if (Mass > 0)
            {
                OutCenterOfMass /= Mass;
            }
        }
        
        return OutCenterOfMass;
    }

    public float GetMass()
    {
        float Mass = 0;
        
        foreach (Rigidbody2D Body in GetAllIncludedBodies())
        {
            Mass += Body.mass;
        }
        
        return Mass;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(GetCenterOfMass(), 1f);
    }

    private void Update()
    {
        GravityCenter.transform.position = GetCenterOfMass();
        GravityCenter.forceMagnitude = GetMass() * GravityForceFactor;
    }
}
