using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    //TODO ref to global scrypt

    bool isGameOver;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Meteor"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
