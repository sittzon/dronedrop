using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneControls : MonoBehaviour
{
    public GameObject presentPrefab;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    float horizontalAccelerationForceConstant = 7.0f;
    float verticalAccelerationForceConstant = 10.0f;
    float decXForceConstant = -1.0f;
    float rotationDecelerationConstant = 5f;
    float halfScreenWidth;
    float halfScreenHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        halfScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        halfScreenHeight = Camera.main.orthographicSize;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Touch controls
        // Right side for up, left side for present drop

        // Input.GetTouch(0).position returns position in device pixel coordinates, (0,0) in lower left corner
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);
            Vector2 touchPos = touch.position;
            print(touchPos);

            // If touch is on right side
            if (touchPos.x > Screen.currentResolution.width / 2)
            {
                rb.AddForce(new Vector2(0.0f, verticalAccelerationForceConstant));
            }
            // If touch is on left side
            else if (touchPos.x < Screen.currentResolution.width / 2)
            {
                Vector3 p = gameObject.transform.position;
                Vector2 vel = gameObject.GetComponent<Rigidbody2D>().velocity;
                GameObject g = Instantiate(presentPrefab, new Vector3(p.x, p.y - 1.0f, p.z), Quaternion.identity);
                g.GetComponent<Rigidbody2D>().velocity = new Vector2(vel.x, vel.y);
            }

            //// Touch controls or keyboard for debugging
            //if (Input.touchCount == 1 || Input.GetKey(KeyCode.UpArrow))
            //{
            //    rb.AddForce(new Vector2(0.0f, verticalAccelerationForceConstant));
            //}
            //if (Input.touchCount >= 2 || Input.GetKeyDown(KeyCode.Space))
            //{
            //    Vector3 pos = gameObject.transform.position;
            //    Vector2 vel = gameObject.GetComponent<Rigidbody2D>().velocity;
            //    GameObject g = Instantiate(presentPrefab, new Vector3(pos.x, pos.y-1.0f, pos.z), Quaternion.identity);
            //    g.GetComponent<Rigidbody2D>().velocity = new Vector2(vel.x, vel.y);
            //}
        }





        // Left/Right input
        float accX = Input.acceleration.x;
        rb.AddForce(new Vector2(horizontalAccelerationForceConstant*accX, 0.0f));
        // Keyboard
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-horizontalAccelerationForceConstant, 0.0f));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(horizontalAccelerationForceConstant, 0.0f));
        }


        // Deceleration
        if (rb.GetRelativeVector(new Vector2(1.0f, 1.0f)).x > 0.0f)
        {
            rb.AddForce(new Vector2(decXForceConstant * accX, 0.0f));
        }

        // Rotation Deceleration
        //float r = rb.rotation;
        //print("Rotation: " + r);
        //if (r > 10f)
        //{
        //    rb.SetRotation(r - rotationDecelerationConstant);
        //}
        //else if (r < 10f)
        //{
        //    rb.SetRotation(r + rotationDecelerationConstant);
        //}

        // Bounds check
        Vector2 pos = gameObject.transform.position;
        if (pos.x - sr.bounds.extents.x < -halfScreenWidth) //Left
        {
            gameObject.transform.position = new Vector2(-halfScreenWidth + sr.bounds.extents.x, pos.y);
            rb.velocity = new Vector2(-rb.velocity.x/2, rb.velocity.y);
        }
        else if (pos.x + sr.bounds.extents.x  > halfScreenWidth) //Right
        {
            gameObject.transform.position = new Vector2(halfScreenWidth - sr.bounds.extents.x, pos.y);
            rb.velocity = new Vector2(-rb.velocity.x/2, rb.velocity.y);
        }
        if (pos.y + sr.bounds.extents.y  > halfScreenHeight) //Top
        {
            gameObject.transform.position = new Vector2(pos.x, halfScreenHeight - sr.bounds.extents.y);
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
        else if (pos.y - sr.bounds.extents.y < -halfScreenHeight) //Bottom
        {
            gameObject.transform.position = new Vector2(pos.x, -halfScreenHeight + sr.bounds.extents.y);
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }
}


