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

        if (gameObject.tag == "cloud")
        {
            minSpeed = 0.05f;
            variability = 0.02f;
        }
        else if (gameObject.tag == "city_bkg")
        {
            minSpeed = 0.05f;
            variability = 0.015f;
        }
        else if (gameObject.tag == "house")
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
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float z = gameObject.transform.position.z;
        gameObject.transform.position = new Vector3(x - movementSpeed, y, z);
    }
}
