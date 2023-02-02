using System.Collections.Generic;
using UnityEngine;

public class MonobehObjectPooler<T> where T : MonoBehaviour
{
    private T _prefab;
    private List<T> _poolList;
    private Transform _container;

    public MonobehObjectPooler(T prefab, Transform container, int count)
    {
        _prefab = prefab;
        _container = container;

        CreatePool(count);
    }

    public T GetFreeMonobehObject()
    {
        if (HasFreeObject(out T prefab))
            return prefab;
        else return CreateObject(true);

        throw new System.Exception("There is no objects in pool");
    }

    private void CreatePool(int count)
    {
        _poolList = new List<T>();

        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var prefab = Object.Instantiate(_prefab, _container);
        prefab.gameObject.SetActive(isActiveByDefault);
        _poolList.Add(prefab);
        return prefab;
    }

    private bool HasFreeObject(out T prefab)
    {
        foreach (var obj in _poolList)
            if (!obj.gameObject.activeInHierarchy)
            {
                prefab = obj;
                prefab.gameObject.SetActive(true);
                return true;
            }
        prefab = null;
        return false;
    }
}