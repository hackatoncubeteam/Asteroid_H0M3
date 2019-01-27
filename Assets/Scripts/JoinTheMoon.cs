﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinTheMoon : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float joiningIndex;

    [SerializeField] Transform planetPos;

    [SerializeField] Behaviour toDisable;

    [SerializeField] bool isEnableMerge = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        planetPos = GameObject.FindGameObjectWithTag("Planet").GetComponent<Transform>();
    }


    void OnCollisionEnter2D(Collision2D col)
    {        
        rb.velocity = Vector2.zero;
        if(col.transform.parent.CompareTag("Planet"))
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        else if(col.transform.CompareTag("Planet"))
            rb.constraints = RigidbodyConstraints2D.FreezeAll;


        var distance = Vector3.Distance(transform.position, planetPos.position);
        if (isEnableMerge == true)
        transform.position = Vector3.MoveTowards(transform.position, transform.position * distance * joiningIndex, transform.localScale.x * joiningIndex);
        gameObject.transform.SetParent(col.transform);

        toDisable.enabled = false;
    }
}