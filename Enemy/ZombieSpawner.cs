using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _spawnPoints;
    [SerializeField] Zombie _enemy;

    private MonobehObjectPooler<Zombie> _pooler;
    private bool _isCoroutineStarted;
    private bool _isAbleToSpawn = true;
    private WaitForSeconds _spawnTimer;

    // TEST
    public bool IsAbleToSpawnTest;
    public int MobCount;

    private void Start()
    {
        _spawnTimer = new WaitForSeconds(1f);
        _pooler = new MonobehObjectPooler<Zombie>(_enemy, transform, 3);
    }

    private void Update()
    {
        // TEST
        if (IsAbleToSpawnTest)
        {
            IsAbleToSpawnTest = false;
            StartCoroutine(SpawnCoroutine(MobCount));
        }
    }

    public void SpawnControlPoint()
    {
        if (_isAbleToSpawn)
        {
            _isAbleToSpawn = false;
            StartCoroutine(SpawnCoroutine(3));
        }
    }

    public void SpawnCoroutineSettings(int count)
    {
        if (!_isCoroutineStarted)
            StartCoroutine(SpawnCoroutine(count));
    }

    private IEnumerator SpawnCoroutine(int count)
    {
        _isCoroutineStarted = true;
        int spawnCount = 0;
        while (spawnCount < count)
        {
            var prefab = _pooler.GetFreeMonobehObject();
            prefab.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position;
            spawnCount++;
            yield return _spawnTimer;
        }
        _isCoroutineStarted = false;
        _isAbleToSpawn = true;
    }
}