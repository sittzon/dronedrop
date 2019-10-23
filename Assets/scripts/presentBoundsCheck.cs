using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presentBoundsCheck : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    float halfScreenWidth;
    float halfScreenHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        halfScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        halfScreenHeight = Camera.main.orthographicSize;

    }

    // Update is called once per frame
    void Update()
    {
        // Bounds check
        Vector2 pos = gameObject.transform.position;
        if (pos.x + sr.bounds.extents.x < -halfScreenWidth) //Left
        {
            Destroy(this);
        }
        else if (pos.x + sr.bounds.extents.x > halfScreenWidth) //Right
        {
            Destroy(this);
        }
        if (pos.y + sr.bounds.extents.y > halfScreenHeight) //Top
        {
            Destroy(this);
        }
        else if (pos.y - sr.bounds.extents.y < -halfScreenHeight) //Bottom
        {
            Destroy(this);
        }
    }
}
