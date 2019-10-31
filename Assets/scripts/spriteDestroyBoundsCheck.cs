﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteDestroyBoundsCheck : MonoBehaviour
{
    private SpriteRenderer sr;
    float halfScreenWidth;
    float halfScreenHeight;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();

        halfScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        halfScreenHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        // Bounds check - Destroy if outside
        Vector2 pos = gameObject.transform.position;
        if (pos.x + sr.bounds.extents.x < -halfScreenWidth) //Left
        {
            print("Gameobject <" + gameObject.ToString() + "> out of Left bounds, destroying");
            Destroy(gameObject);
        }
        else if (pos.x + sr.bounds.extents.x > halfScreenWidth) //Right
        {
            print("Gameobject <" + gameObject.ToString() + "> out of Right bounds, destroying");
            Destroy(gameObject);
        }
        if (pos.y + sr.bounds.extents.y > halfScreenHeight) //Top
        {
            print("Gameobject <" + gameObject.ToString() + "> out of Top bounds, destroying");
            Destroy(gameObject);
        }
        else if (pos.y - sr.bounds.extents.y < -halfScreenHeight) //Bottom
        {
            print("Gameobject <" + gameObject.ToString() + "> out of Bottom bounds, destroying");
            Destroy(gameObject);
        }
    }
}
