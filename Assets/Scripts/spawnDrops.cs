using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDrops : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnTime = 0.2f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemyWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(enemyPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range((3 * screenBounds.x / 4) * 1.5f, screenBounds.x * 2.5f), screenBounds.y * 1.5f);
    }

    IEnumerator enemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
