using UnityEngine;

public class Drone : MonoBehaviour
{
    public GameObject presentPrefab;

    Rigidbody2D rb;
    SpriteRenderer sr;
    float horizontalAccelerationForceConstant = 7.0f;
    float verticalAccelerationForceConstant = 10.0f;
    float maxVelXConstant = 3.0f;
    float halfScreenWidth;
    float halfScreenHeight;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        halfScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        halfScreenHeight = Camera.main.orthographicSize;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Touch controls
        // Left side for up, right side for present drop
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Vector2 touchPos = Input.GetTouch(i).position;

            // If touch is on left side
            if (touchPos.x < Screen.currentResolution.width / 2)
            {
                goUp();
            }
            // If touch is on right side
            else if (touchPos.x > Screen.currentResolution.width / 2 && Input.GetTouch(i).phase == TouchPhase.Began)
            {
                dropPresent();
            }
        }

        // Left/Right tilt
        float accX = Input.acceleration.x;
        if (rb.velocity.x < maxVelXConstant || rb.velocity.x > -maxVelXConstant)
        {
            rb.AddForce(new Vector2(horizontalAccelerationForceConstant * accX, 0.0f));
        }

        // Rotate drone
        rb.rotation = -rb.velocity.x * 2.0f;


        // Keyboard controls for debugging
        if (Debug.isDebugBuild) {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                goUp();
            }
            if (Input.GetKey(KeyCode.Space) && Input.anyKeyDown)
            {
                dropPresent();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(new Vector2(-horizontalAccelerationForceConstant, 0.0f));
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(new Vector2(horizontalAccelerationForceConstant, 0.0f));
            }
        }

        // Bounds check
        Vector2 pos = transform.position;
        if (pos.x - sr.bounds.extents.x < -halfScreenWidth) //Left
        {
            transform.position = new Vector2(-halfScreenWidth + sr.bounds.extents.x, pos.y);
            rb.velocity = new Vector2(-rb.velocity.x/2, rb.velocity.y);
        }
        else if (pos.x + sr.bounds.extents.x  > halfScreenWidth) //Right
        {
            transform.position = new Vector2(halfScreenWidth - sr.bounds.extents.x, pos.y);
            rb.velocity = new Vector2(-rb.velocity.x/2, rb.velocity.y);
        }
        if (pos.y + sr.bounds.extents.y  > halfScreenHeight) //Top
        {
            transform.position = new Vector2(pos.x, halfScreenHeight - sr.bounds.extents.y);
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
        else if (pos.y - sr.bounds.extents.y < -halfScreenHeight) //Bottom
        {
            transform.position = new Vector2(pos.x, -halfScreenHeight + sr.bounds.extents.y);
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }

    void goUp()
    {
        rb.AddForce(new Vector2(0.0f, verticalAccelerationForceConstant));
    }

    void dropPresent()
    {
        Vector3 p = transform.position;
        Vector2 vel = GetComponent<Rigidbody2D>().velocity;
        GameObject go = Instantiate(presentPrefab, new Vector3(p.x, p.y - 1.0f, p.z), Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(vel.x, vel.y);
    }

    public void setScore(int score)
    {
        this.score = score;
    }

    public int getScore()
    {
        return this.score;
    }
}


