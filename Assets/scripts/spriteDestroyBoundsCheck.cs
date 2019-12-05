using UnityEngine;

public class spriteDestroyBoundsCheck : MonoBehaviour
{
    private SpriteRenderer sr;
    float halfScreenWidth;
    float halfScreenHeight;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        halfScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        halfScreenHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        // Bounds check - Destroy if outside
        Vector2 pos = transform.position;
        if (pos.x + sr.bounds.extents.x < -halfScreenWidth) //Left
        {
            print("Gameobject <" + ToString() + "> out of Left bounds, destroying");
            Destroy(gameObject);
        }
        else if (pos.x + sr.bounds.extents.x > halfScreenWidth) //Right
        {
            print("Gameobject <" + ToString() + "> out of Right bounds, destroying");
            Destroy(gameObject);
        }
        if (pos.y + sr.bounds.extents.y > halfScreenHeight) //Top
        {
            print("Gameobject <" + ToString() + "> out of Top bounds, destroying");
            Destroy(gameObject);
        }
        else if (pos.y - sr.bounds.extents.y < -halfScreenHeight) //Bottom
        {
            print("Gameobject <" + ToString() + "> out of Bottom bounds, destroying");
            Destroy(gameObject);
        }
    }
}
