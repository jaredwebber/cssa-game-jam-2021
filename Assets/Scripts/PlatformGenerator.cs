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

    public float respawnTime = 2.0f;
    int whichObject;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(3, 0, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector3 sharkPos = shark.transform.position;
        GameObject start = Instantiate(startPlatform) as GameObject;
        start.transform.position = sharkPos;
        GameObject middle1 = Instantiate(middlePlatform) as GameObject;
        GameObject middle2 = Instantiate(middlePlatform) as GameObject;
        GameObject middle3 = Instantiate(middlePlatform) as GameObject;
        middle1.transform.position = sharkPos + offset;
        middle2.transform.position = sharkPos + 2*offset;
        middle3.transform.position = sharkPos + 3*offset;
        GameObject end = Instantiate(endPlatform) as GameObject;
        end.transform.position = sharkPos + 4*offset;

        StartCoroutine(PFWave());
    }

    private void spawnPF()
    {
        int PFsize = UnityEngine.Random.Range(0, 3);
        float y = UnityEngine.Random.Range(-screenBounds.y + 0.1f, screenBounds.y - 0.1f);
        GameObject[] pfs = new GameObject[PFsize + 2];
        pfs[0] = Instantiate(startPlatform) as GameObject;
        pfs[0].transform.position = new Vector2(screenBounds.x * 1.1f, y);

        for (int i = 0; i < PFsize; i++)
        {
            pfs[1 + i] = Instantiate(middlePlatform) as GameObject;
            pfs[1 + i].transform.position = new Vector2(screenBounds.x * 1.1f + ((1 + i) * offset.x), y);
        }
        pfs[PFsize + 1] = Instantiate(endPlatform) as GameObject;
        pfs[PFsize + 1].transform.position = new Vector2(screenBounds.x * 1.1f + ((PFsize + 1) * offset.x), y);

        respawnTime = (7 * PFsize) + (UnityEngine.Random.Range(-2, 2));
    }

    IEnumerator PFWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPF();
        }

    }

}
