using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrawnFactory : MonoBehaviour
{
    public GameObject prawn;

    public float spawnTime;

    private float trueSpawnTime;
    private Vector3 randomSpawn;
    // Start is called before the first frame update
    void Start()
    {
        trueSpawnTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime > 0) {
            spawnTime -= Time.deltaTime;
        }
        else {
            randomSpawn = new Vector3(Random.Range(-120, 150), -70, -9);
            Instantiate(prawn, randomSpawn, transform.rotation);
            spawnTime = trueSpawnTime;
        }
    }
}
