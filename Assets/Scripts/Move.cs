using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    public float meteorSpeed;
    Vector2 moonPosition;

    float rotation;

    // Start is called before the first frame update
    void Start()
    {
        //moonPosition = .GetComponent<Transform>().position;
        //rb = GetComponent<Rigidbody2D>();
        //
        //rotation = Random.Range(-vectorRotationAngle, vectorRotationAngle);
        //
        //ToTheMoon();
    }

    
    void ToTheMoon(Vector3 Direction)
    {        
        //float randAng = Random.Range(2, 4);
        //
        //Vector2 curPos = transform.position;
        //
        //Vector3 forceDirection = (moonPosition - curPos).normalized;
        //forceDirection = Quaternion.Euler(0, 0, randAng) * forceDirection;
        //
        //rb.AddForce(moonPosition - curPos, ForceMode2D.Impulse);
        //
        //rb.velocity *= 0.5f;
    }
}
