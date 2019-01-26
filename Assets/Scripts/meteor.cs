using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    Vector3 curMeteorPosition;
    Vector3 planetPosition;
    

    Rigidbody2D rb;


    void Start()
    {
        planetPosition = GameObject.FindGameObjectWithTag("Planet").GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.Log("Meteor has no rigidbody");
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, planetPosition);
        var sos = 0.5f / distance;

        rb.AddForce((planetPosition - transform.position) * sos * 2, ForceMode2D.Force);
    }
}
