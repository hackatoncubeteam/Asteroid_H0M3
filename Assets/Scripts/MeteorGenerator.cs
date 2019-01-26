using System.Collections.Generic;
using UnityEngine;


public class MeteorGenerator : MonoBehaviour
{
    BezierCurve bc;

    List<Transform> meteorSpawnPosition;

    GameObject meteor;

    float timer;


    Random rnd;

    void Start()
    {
        bc = GetComponent<BezierCurve>();
        //if()
    }

    //void SpawnMeteor()
    //{
    //    Instantiate(meteor, Random.)
    //}
}
