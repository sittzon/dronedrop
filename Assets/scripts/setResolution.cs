using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // iPhone 5/5s/SE
        // Switch to 1136 x 640 fullscreen
        Screen.SetResolution(1136, 640, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
