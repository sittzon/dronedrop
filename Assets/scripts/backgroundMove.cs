using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMove : MonoBehaviour
{
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = Random.value/10f;
    }

    // Update is called once per frame
    void Update()
    {
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float z = gameObject.transform.position.z;
        gameObject.transform.position = new Vector3(x - movementSpeed, y, z);

        // Outside bounds -> Destroy
        if (x < -14f)
        { 
            Destroy(this);
        }
    }
}
