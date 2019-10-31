using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMove : MonoBehaviour
{
    private float minSpeed, variability;
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = Random.value;   // [0 - 1]

        if (CompareTag("cloud"))
        {
            minSpeed = 0.05f;
            variability = 0.02f;
        }
        else if (CompareTag("city_bkg"))
        {
            minSpeed = 0.05f;
            variability = 0.015f;
        }
        else if (CompareTag("house"))
        {
            minSpeed = 0.05f;
            variability = 0.015f;
        }
        movementSpeed *= variability; // [0 - variability]
        movementSpeed += minSpeed;    // [minSpeed - minSpeed+variability]
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        transform.position = new Vector3(x - movementSpeed, y, z);
    }
}
