using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _enemyPrefab;

    [Header("Spawn Settings")]
    [SerializeField, Min(0.1f)] private float _spawnInterval = 2f;
    [SerializeField, Min(0f)] private float _spawnMargin = 2f;
    [SerializeField, Min(0f)] private float _initialDelay = 1f;
    [SerializeField, Min(0f)] private int _maxEnemies = 30;

    private readonly List<GameObject> _spawnedEnemies = new();

    private void Awake()
    {
        if (_camera == null) _camera = Camera.main;
    }

    private void Start()
    {
        if (_camera == null || _enemyPrefab == null)
        {
            Debug.LogError("EnemySpawner: atribua a Camera e o Enemy Prefab no Inspector.", this);

            enabled = false;
            return;
        }

        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine () 
    {
        yield return new WaitForSeconds(_initialDelay);

        while (true)
        {
            ClearEnemyList();

            if (_spawnedEnemies.Count < _maxEnemies) SpawnEnemy();

            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        float depth = Mathf.Abs(_camera.transform.position.z - _enemyPrefab.transform.position.z);

        Vector3 bottomLeft = _camera.ViewportToWorldPoint(new Vector3(0f, 0f, depth));

        Vector3 topRight = _camera.ViewportToWorldPoint( new Vector3(1f, 1f, depth));

        float minX = bottomLeft.x;
        float maxX = topRight.x;
        float minY = bottomLeft.y;
        float maxY = topRight.y;

        Vector2 spawnPosition;

        // 0 = esquerda
        // 1 = direita
        // 2 = baixo
        // 3 = cima
        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0:
                spawnPosition = new Vector2(minX - _spawnMargin, Random.Range(minY, maxY));
                break;

            case 1:
                spawnPosition = new  Vector2(maxX + _spawnMargin, Random.Range(minY, maxY));
                break;

            case 2:
                spawnPosition = new Vector2(Random.Range(minX, maxX), minY - _spawnMargin);
                break;

            default:
                spawnPosition = new Vector2(Random.Range(minX, maxX), maxY - _spawnMargin);
                break;
        }

        Vector3 finalPosition = new Vector3(spawnPosition.x, spawnPosition.y, _enemyPrefab.transform.position.z);

        GameObject enemy = Instantiate(_enemyPrefab, finalPosition, _enemyPrefab.transform.rotation);

        _spawnedEnemies.Add(enemy);
    }

    private void ClearEnemyList() 
    {
        _spawnedEnemies.RemoveAll(enemy => enemy == null);
    }

}
