using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject startPlatform, middlePlatform, endPlatform, shark;

    int currPlatform, prevPlatform;

    private Vector2 screenBounds;
    private Vector3 offset;

    public float PFrespawnTime = 0.0f;
    int whichObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PFWave());

        offset = new Vector3(3, 0, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector3 sharkPos = shark.transform.position;
        GameObject start = Instantiate(startPlatform) as GameObject;
        start.transform.position = sharkPos;
        GameObject[] pfs = new GameObject[4];
        int i = 0;
        for(; i < pfs.Length; i++)
        {
            pfs[i] = Instantiate(middlePlatform) as GameObject;
            pfs[i].transform.position = sharkPos + ((i + 1) * offset);
        }
        GameObject end = Instantiate(endPlatform) as GameObject;
        end.transform.position = sharkPos + ((i + 1) * offset);
    }

    private void spawnPF()
    {
        int PFsize = UnityEngine.Random.Range(0, 3);
        float y = UnityEngine.Random.Range(-screenBounds.y + 0.1f, screenBounds.y - 0.1f);
        GameObject[] pfs = new GameObject[PFsize + 2];
        pfs[0] = Instantiate(startPlatform) as GameObject;
        pfs[0].transform.position = new Vector2(screenBounds.x * 1.2f, y);

        for (int i = 0; i < PFsize; i++)
        {
            pfs[1 + i] = Instantiate(middlePlatform) as GameObject;
            pfs[1 + i].transform.position = new Vector2(screenBounds.x * 1.2f + ((1 + i) * offset.x), y);
        }
        pfs[PFsize + 1] = Instantiate(endPlatform) as GameObject;
        pfs[PFsize + 1].transform.position = new Vector2(screenBounds.x * 1.2f + ((PFsize + 1) * offset.x), y);

        PFrespawnTime = (3*(PFsize + 2)) + (UnityEngine.Random.Range(-2, 2));
    }

    IEnumerator PFWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(PFrespawnTime);
            spawnPF();
        }

    }

}
