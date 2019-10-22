using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upButton : MonoBehaviour
{
    GameObject drone;

    // Start is called before the first frame update
    void Start()
    {
        drone = GameObject.Find("drone");
        print(drone.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 pos = touch.position;

                print("Touch position: " + pos);
            }
        }
    }
}
