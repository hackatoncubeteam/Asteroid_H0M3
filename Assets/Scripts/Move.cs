using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    public float meteorSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * 2, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //float step = meteorSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left, step);
    }
}
