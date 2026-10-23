using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SurvivalTimer survivalTimer;
    [SerializeField] private EnemySpawner enemySpawner;

    [Header("Wave Config")]
    [SerializeField] private float waveDuration = 30f;
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private int enemiesPerWave = 3;

    [Header("Difficulty")]
    [SerializeField] private float initialSpawnInterval = 1.5f;
    [SerializeField] private float intervalReduction = 0.08f;
    [SerializeField] private float minimumSpawnInterval = 0.4f;

    public int CurrentWave { get; private set; } = 1;

    private void Start()
    {
        StartCoroutine(RunWaves());
    }

    private IEnumerator RunWaves() 
    {
        while (true)
        {
            float waveStartTime = Time.time;

            int enemyCount = baseEnemies + (CurrentWave - 1) * enemiesPerWave;

            float spawnIntervel = Mathf.Max(minimumSpawnInterval, initialSpawnInterval - (CurrentWave -1) * intervalReduction);

            for (int i = 0; i < enemyCount; i++)
            {
                enemySpawner.SpawnEnemy();

                yield return new WaitForSeconds(spawnIntervel);
            }

            float elapsed = Time.time - waveStartTime;
            float remaining = waveDuration - elapsed;

            if(remaining > 0f) yield return new WaitForSeconds(remaining);

            CurrentWave++;
        }
    }

}
