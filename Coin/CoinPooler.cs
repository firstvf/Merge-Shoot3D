using System.Collections.Generic;
using UnityEngine;

public class CoinPooler
{
    private GameObject _prefab;
    private List<GameObject> _poolList;
    private Transform _container;

    public CoinPooler(GameObject prefab, int count,Transform container)
    {
        _prefab = prefab;
        _container = container;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _poolList = new List<GameObject>();

        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private Coin CreateObject(bool isActiveByDefault = false)
    {
        var prefab = Object.Instantiate(_prefab, _container.position, Quaternion.identity,_container);
        prefab.SetActive(isActiveByDefault);
        _poolList.Add(prefab);
        return prefab.GetComponent<Coin>();
    }

    private bool HasFreeCoin(out Coin coin)
    {
        foreach (var prefab in _poolList)
            if (!prefab.activeInHierarchy)
            {
                coin = prefab.GetComponent<Coin>();
                prefab.SetActive(true);
                return true;
            }
        coin = null;
        return false;
    }

    public Coin GetFreeCoin()
    {
        if (HasFreeCoin(out var coin))
            return coin;
        else
            return CreateObject(true);

        throw new System.Exception("There is no coin in pool");
    }
}