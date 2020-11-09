using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coins;
    public float CoinSpawnRate = 7.0f; //calculated in seconds

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCoins", CoinSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnCoins()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(1, 5));

        Vector2 max = Camera.main.ScreenToWorldPoint(new Vector2(1, 1));

        GameObject aPlatform = (GameObject)Instantiate(Coins);
        aPlatform.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        NextCoinSpawn();
    }

    void NextCoinSpawn()
    {
        float spawnSpeed;

        if (CoinSpawnRate > 7.0f)
        {
            spawnSpeed = Random.Range(1f, CoinSpawnRate);
        }
        else
            spawnSpeed = 7.0f;

        Invoke("SpawnCoins", spawnSpeed);
    }
}
