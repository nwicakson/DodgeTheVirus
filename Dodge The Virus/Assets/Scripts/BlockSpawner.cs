using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public Transform[] spawnPoints;

	public GameObject blockPrefab;

	public float timeBetweenWaves;

	private float timeToSpawn = 2f;

    void Start()
    {
        InvokeRepeating("SpawnBlocks", timeToSpawn, timeBetweenWaves);
    }

	void SpawnBlocks ()
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);

		for (int i = 0; i < spawnPoints.Length; i++)
		{
            if (randomIndex != i)
			{
                float randomAgain = Random.Range(0, 10);
                if(randomAgain > 1)
                {
                    Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                }
			}
		}
	}
	
}
