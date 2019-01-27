using System.Collections.Generic;
using UnityEngine;


public class MeteorGenerator : MonoBehaviour
{[SerializeField] GameObject meteor;

    [SerializeField] float timer;

    [SerializeField] float LaunchOffset = 30.0f;

    [SerializeField] float LaunchForce = 10.0f;

    [SerializeField] private BezierCurve GeneratorCurve;

    float time;

    [SerializeField]
    Transform Moon;

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
        GameObject NewMeteor = Instantiate(meteor, GeneratorCurve.GetPointAt(Random.value), Quaternion.identity);
        var MeteorBody = NewMeteor.GetComponent<Rigidbody2D>();

        Vector3 forceDirection = (Moon.position - NewMeteor.transform.position).normalized;

        forceDirection = Quaternion.Euler(0, 0, Random.Range(-LaunchOffset, LaunchOffset)) * forceDirection;

        MeteorBody.AddForce(forceDirection * LaunchForce, ForceMode2D.Impulse);
    }
}
