using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject PlatformGO;
    public float SpawnRate = .5f; //calculated in seconds

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnPlatform", SpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlatform()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(1, 5));

        Vector2 max = Camera.main.ScreenToWorldPoint(new Vector2(1, 1));

        GameObject aPlatform = (GameObject)Instantiate(PlatformGO);
        aPlatform.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

        NextPlatformSpawn();
    }

    void NextPlatformSpawn()
    {
        float spawnSpeed;

        if (SpawnRate > .5f)
        {
            spawnSpeed = Random.Range(1f, SpawnRate);
        }
        else
            spawnSpeed = .5f;

        Invoke("SpawnPlatform", spawnSpeed);
    }
}
