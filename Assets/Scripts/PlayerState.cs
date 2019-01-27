using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //TODO ref to global scrypt

    bool isGameOver;

    void OnTriggerEnter2D(Collision2D col)
    {
        isGameOver = true;
    }
}
