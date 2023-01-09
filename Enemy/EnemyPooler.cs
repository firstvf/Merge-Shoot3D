using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler
{
    private GameObject _prefab;
    private GameObject[] _spawnPositions;
    private List<GameObject> _poolList;
    private Transform _container;

    public EnemyPooler(GameObject prefab, int count, GameObject[] positions,Transform container)
    {
        _container = container;
        _prefab = prefab;
        _spawnPositions = positions;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _poolList = new List<GameObject>();

        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private GameObject CreateObject(bool isActiveByDefault = false)
    {
        var prefab = Object.Instantiate(_prefab, _spawnPositions[Random.Range(0, _spawnPositions.Length)].transform.position, Quaternion.identity,_container);
        prefab.SetActive(isActiveByDefault);
        _poolList.Add(prefab);
        return prefab;
    }

    private bool HasFreeUnit(out GameObject prefab)
    {
        foreach (var enemy in _poolList)
            if (!enemy.activeInHierarchy)
            {
                prefab = enemy;
                enemy.transform.position = _spawnPositions[Random.Range(0, _spawnPositions.Length)].transform.position;
                enemy.SetActive(true);
                return true;
            }
        prefab = null;
        return false;
    }

    public GameObject GetFreeUnit()
    {
        if (HasFreeUnit(out GameObject prefab))
            return prefab;
        else
            return CreateObject(true);

        throw new System.Exception("There is no units in pool");
    }
}