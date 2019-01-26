using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexMassController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
