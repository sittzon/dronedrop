using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public int destroyAfter = 10;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = destroyAfter;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter <= 0)
        {
            Destroy(gameObject);
        }
        --counter;
    }
}
