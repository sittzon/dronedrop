using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkgDestroyBoundsCheck : MonoBehaviour
{
    private SpriteRenderer sr;
    float halfScreenWidth;
    float halfSpriteWidth;

    // Start is called before the first frame update
    void Start()
    {
        halfSpriteWidth = gameObject.GetComponent<SpriteRenderer>().bounds.extents.x;
        halfScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        // Bounds check - Destroy if outside
        Vector2 pos = gameObject.transform.position;
        if (pos.x + halfSpriteWidth < -halfScreenWidth) //Left
        {
            print("Gameobject <" + gameObject.ToString() + "> out of Left bounds, destroying");
            Destroy(gameObject);
        }
    }
}
