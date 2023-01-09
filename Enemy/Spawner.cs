using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] _spawnPoints;
    [SerializeField] GameObject _enemy;
    private EnemyPooler _pooler;
    private bool _isCoroutineStarted;
    private bool _isAbleToSpawn = true;
    private WaitForSeconds _spawnTimer;

    private void Start()
    {
        _spawnTimer = new WaitForSeconds(1f);
        _pooler = new EnemyPooler(_enemy, 3, _spawnPoints,transform);
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
            var prefab = _pooler.GetFreeUnit();
            spawnCount++;
            yield return _spawnTimer;
        }
        _isCoroutineStarted = false;
        _isAbleToSpawn = true;
    }
}