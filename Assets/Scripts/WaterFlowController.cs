using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlowController : MonoBehaviour
{
    [SerializeField]
    private CharacterMovement Shooter;
    
    [SerializeField]
    private WaterFlow WaterFlow;

    [SerializeField]
    private float RecoilForce = 10.0f;

    [SerializeField]
    private float BustedRecoilForce = 10.0f;
    
    public void SetState(bool NewState)
    {
        WaterFlow.gameObject.SetActive(NewState);
        enabled = NewState;
    }

    void Update()
    {
        Shooter.AddWorldForce(WaterFlow.GetFlowVector().normalized * -RecoilForce * Time.deltaTime);
    }
}
