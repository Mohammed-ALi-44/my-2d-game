using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	// Enemy 
	[SerializeField] List<WaveConfig> waveConfigs;
	[SerializeField] int startingWave = 0;
	[SerializeField] bool looping;
	// Asteroids
	public GameObject asteroid;
	public Vector2 asteroidPos;
	//wait&win
	public float timeToWin;
	public GameObject winCol;

	IEnumerator Start () 
	{
		InvokeRepeating("AsteroidSpawner", 1f, Random.Range(1f,4f));
		do
		{
			yield return StartCoroutine(SpawnAllWaves());
		} while (looping);
	}
	IEnumerator SpawnAllWaves()
    {
		for(int waveIndex = startingWave; waveIndex< waveConfigs.Count; waveIndex++)
        {
			var currentWave = waveConfigs[waveIndex];
			
			yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));

        }
		yield return StartCoroutine(WaitAndWin());

    }
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
		for (int enemyCount = 0;enemyCount < waveConfig.GetNumbersOfEnemies(); enemyCount++) 
		{
			var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);

			newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

			yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
		}
    }
	void AsteroidSpawner()
    {
		Vector2 newAsteroidPos = new Vector2(Random.Range(-asteroidPos.x, asteroidPos.x), asteroidPos.y);
		Instantiate(asteroid, newAsteroidPos, transform.rotation);
    }
	IEnumerator WaitAndWin()
    {
		yield return new WaitForSeconds(timeToWin);
		winCol.SetActive(true);
    }
}
