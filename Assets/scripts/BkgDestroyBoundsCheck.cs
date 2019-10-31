using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkgDestroyBoundsCheck : MonoBehaviour
{
    float halfScreenWidth;
    float halfSpriteWidth;

    Renderer rend;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        halfSpriteWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        halfScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        // Bounds check - Destroy if outside
        Vector2 pos = transform.position;
        if (pos.x + halfSpriteWidth < -halfScreenWidth) //Left
        {
            print("Gameobject <" + ToString() + "> out of Left bounds, destroying");
            Destroy(gameObject);
        }
    }

    // Draws a wireframe sphere in the Scene view, fully enclosing
    // the object.
    void OnDrawGizmosSelected()
    {
        rend = GetComponent<Renderer>();

        // A sphere that fully encloses the bounding box.
        Vector3 center = rend.bounds.center;
        float radius = rend.bounds.extents.magnitude;

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(center, radius);
    }
}
