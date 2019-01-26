using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }
}
