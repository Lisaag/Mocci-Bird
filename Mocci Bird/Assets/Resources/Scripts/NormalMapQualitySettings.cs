using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class NormalMapQualitySettings : MonoBehaviour
{
    Light2D light2D = null;

    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
        light2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
