using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInstantiate : MonoBehaviour
{
    public GameObject cityPrefab;
    public GameObject cloudPrefab;
    public GameObject housePrefab1;

    Vector2 cityStartPos = new Vector2(14f, -2.45f);
    Vector2 cloudStartPos = new Vector2(9.6f, 0f);
    Vector2 house1StartPos = new Vector2(11.2f, -0.5f);

    int cityLastCreated;
    int cloudLastCreated;
    int house1LastCreated;

    SpriteRenderer sr;
    float spriteHalfWidth, spriteHalfHeight;

    float screenHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        screenHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;

        for (int i = 0; i < 15; ++i)
        {
            GameObject go = instantiateCloud();
            sr = go.GetComponent<SpriteRenderer>();
            spriteHalfWidth = sr.sprite.bounds.extents.x;
            spriteHalfHeight = sr.sprite.bounds.extents.y;
            go.transform.position += new Vector3((Random.value - 0.5f) * 4*screenHalfWidth, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value < 0.05f && cityLastCreated <= 0)
        {
            instantiateCity();
        }
        --cityLastCreated;

        if (Random.value < 0.6f && cloudLastCreated <= 0)
        {
            instantiateCloud();
        }
        --cloudLastCreated;

        if (Random.value < 0.1f && house1LastCreated <= 0)
        {
            instantiateHouse1();
        }
        --house1LastCreated;


    }

    private GameObject instantiateHouse1()
    {
        house1LastCreated = 500;
        GameObject go = Instantiate(housePrefab1, house1StartPos, Quaternion.identity);
        go.transform.position += new Vector3(0f, (Random.value - 0.5f) * 0.5f, 0f);
        return go;
    }

    private GameObject instantiateCloud(Vector2 start)
    {
        cloudLastCreated = 15;
        GameObject go = Instantiate(cloudPrefab, start, Quaternion.identity);
        go.transform.position += new Vector3(0f, (Random.value - 0.3f) * 6, 0f);
        //Flip sprite?
        if (Random.value < 0.5f)
        {
            flipSpriteX(go);
        }
        return go;
    }

    private GameObject instantiateCloud()
    {
        return instantiateCloud(cloudStartPos);
    }


    private GameObject instantiateCity(Vector2 start)
    {
        cityLastCreated = 200;
        GameObject go = Instantiate(cityPrefab, cityStartPos, Quaternion.identity);
        //Flip sprite?
        if (Random.value < 0.5f)
        {
            flipSpriteX(go);
        }
        return go;
    }

    private GameObject instantiateCity()
    {
        return instantiateCity(cityStartPos);
    }

    private void flipSpriteX(GameObject go)
    {
        go.transform.localScale = new Vector3(-go.transform.localScale.x, go.transform.localScale.y, go.transform.localScale.z);
    }
}