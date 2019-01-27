using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollution : MonoBehaviour
{
    [SerializeField, Range(0, 100)]
    private float pollutionLevel;

    float PollutionLevel
    {
        get
        {
            return pollutionLevel;
        }
        set
        {
            if (pollutionLevel < 0)
                pollutionLevel = 0;

            value = pollutionLevel;
        }
    }

    public void SetPollutionLevel(float _pollutionLevel)
    {
        pollutionLevel = _pollutionLevel;

        var renderer = GetComponentInChildren<MeshRenderer>();
        
        //renderer.
    }
    

    void Start()
    {
        SetPollutionLevel(100);
    }


    public void GetDamage(float damage)
    {
        SetPollutionLevel(pollutionLevel - damage);
    }
    
}
