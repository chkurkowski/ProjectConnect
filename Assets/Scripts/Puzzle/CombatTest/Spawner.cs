using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate;
    private float currentTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime * spawnRate;

        if (currentTimer >= 10f)
        {
            currentTimer = 0f;
            Spawn();

        }
    }

    public void Spawn()
    {
        ObjectPooler.instance.SpawnFromPool("Enemy", transform.position, Quaternion.identity);
    }


}
