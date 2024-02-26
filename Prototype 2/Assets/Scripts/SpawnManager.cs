using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPositionZ = 20;
    private float startDelay = 2.0f;
    private float spawnInternval = 1.5f;

    // Spawn is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInternval);
    }

    // Spawn an animal at a random animal at a random position 
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);

        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
    }
}
