using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneControls : MonoBehaviour
{
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        print("rigidbody: " + rb.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(0.0f, 1.0f));
        }
    }
}
