using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundInstantiate : MonoBehaviour
{
    public GameObject bkgPrefab;
    int bkgLastCreated = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = Instantiate(bkgPrefab, new Vector3(14f, -2.45f, 0f), Quaternion.identity);
        Screen.SetResolution(1920, 1080, false);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate new city background
        float r1 = Random.value * 100f;
        float r2 = Random.value;
        if (r1 < 5f && bkgLastCreated <= 0)
        {
            bkgLastCreated = 300;
            GameObject g = Instantiate(bkgPrefab, new Vector3(14f, -2.45f, 0f), Quaternion.identity);
            //Flip sprite?
            if (r2 < 0.5f)
            {
                g.transform.localScale = new Vector3(-g.transform.localScale.x, g.transform.localScale.y, g.transform.localScale.z);
            }
        }
        --bkgLastCreated;
    }
}
