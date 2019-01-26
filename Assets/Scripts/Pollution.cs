using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollution : MonoBehaviour
{
    [SerializeField, Range(0, 100)]
    private float PollutionLevel;

    public void SetPollutionLevel(float pollutionLevel)
    {
        PollutionLevel = pollutionLevel;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
