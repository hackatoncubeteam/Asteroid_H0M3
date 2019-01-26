using System.Collections.Generic;
using UnityEngine;


public class MeteorGenerator : MonoBehaviour
{
    BezierCurve bc;

    [SerializeField] GameObject meteor;

    [SerializeField] float timer;

    [SerializeField] float LaunchOffset = 30.0f;

    [SerializeField] float LaunchForce = 10.0f;

    float time;

    [SerializeField]
    Transform Moon;
  

    void Start()
    {
        bc = GameObject.FindGameObjectWithTag("MeteorCurve").GetComponent<BezierCurve>();
        if (bc == null)
            Debug.Log("in MeteorGenerator no reference to BezierCurve");
    }

    void Update()
    {
        if (timer < Time.time - time)
        {
            SpawnMeteor();
            time = Time.time;
        }
    }

    void SpawnMeteor()
    {
        GameObject NewMeteor = Instantiate(meteor, bc.GetPointAt(Random.value), Quaternion.identity);
        var MeteorBody = NewMeteor.GetComponent<Rigidbody2D>();

        Vector3 forceDirection = (Moon.position - NewMeteor.transform.position).normalized;

        forceDirection = Quaternion.Euler(0, 0, Random.Range(-LaunchOffset, LaunchOffset)) * forceDirection;

        MeteorBody.AddForce(forceDirection * LaunchForce, ForceMode2D.Impulse);
    }
}
