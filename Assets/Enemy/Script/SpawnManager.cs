using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> animals = new List<GameObject>();
    public Vector3 spawnRange = new Vector3(20, 0, 0);
    public Vector3 spawnPos = new Vector3(0, 0, 20);

    public float spawnInterval = 1.5f;
    public float startDelay = 2f;

    public List<GameObject> animalInstances = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        if (enabled)
        {
            int animalIndex = Random.Range(0, animals.Count);
            Vector3 instancePos = new Vector3(Random.Range(-spawnRange.x, spawnRange.x), spawnRange.y, spawnRange.z) + spawnPos;
            var instance = Instantiate(animals[animalIndex], instancePos, animals[animalIndex].transform.rotation);
            animalInstances.Add(instance);
        }
    }
    public void Stop()
    {
        enabled = false;
        DestroyAll();
    }
    public void DestroyAll()
    {
        foreach (var instance in animalInstances)
        {
            Destroy(instance);
        }
    }
}
