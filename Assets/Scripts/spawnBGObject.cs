using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBGObject : MonoBehaviour
{
    //prefabs
    public GameObject prefab1, prefab2, prefab3, prefab4, prefab5, prefab6, prefab7, prefab8, prefab9, prefab10, prefab11, prefab12, prefab13, prefab14;
    private GameObject[] prefabs;

    private Vector2 screenBounds;
    public float respawnTime = 2.0f;
    int whichObject;
    

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(BGWave());
    }

    private void spawnObject()
    {
        GameObject[] prefabs = { prefab1, prefab2, prefab3, prefab4, prefab5, prefab6, prefab7, prefab8, prefab9, prefab10, prefab11, prefab12, prefab13, prefab14 };
        whichObject = UnityEngine.Random.Range(0, 13);

        GameObject a = Instantiate(prefabs[whichObject]) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 1.5f, UnityEngine.Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator BGWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObject();
        }

    }
}
