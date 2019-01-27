using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    Pollution pollution;

    [SerializeField] float timer;

    [SerializeField] float givenDamageToMeteors;

    float pastTime;

    private bool _isHitting;


    public Vector3 GetFlowVector()
    {
        return transform.rotation * Vector3.right;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, GetFlowVector());
    }

    public bool IsHitting()
    {
        return _isHitting;
    }

    public void SetActivity(bool Activity)
    {
        _isHitting = false;
        
        gameObject.SetActive(Activity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _isHitting = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isHitting = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        _isHitting = true;

        if (timer < Time.time - pastTime)
        {
            if (other.CompareTag("meteor"))
            {
                pollution = other.gameObject.GetComponent<Pollution>();
                if (pollution == null)
                    Debug.Log("WaterFlow has no reference to Pullution in meteor");

                pollution.GetDamage(givenDamageToMeteors);
            }
        }
    }
}
