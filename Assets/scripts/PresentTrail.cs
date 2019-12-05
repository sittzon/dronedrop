using UnityEngine;

public class PresentTrail : MonoBehaviour
{
    public GameObject PresentTrailObject;
    public int instantiateEvery = 2;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        --counter;
        if (counter <= 0)
        {
            Instantiate(PresentTrailObject,
                new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),
                Quaternion.identity);
            counter = instantiateEvery;
        }
    }
}
