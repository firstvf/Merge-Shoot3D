using System.Collections.Generic;
using UnityEngine;

public class MonobehObjectPooler<T> where T : MonoBehaviour
{
    private readonly Transform _container;
    private readonly T _singlePrefab;
    private List<T> _poolList;

    //private readonly T[] _prefab;

    public MonobehObjectPooler(T prefab, Transform container, int count)
    {
        _singlePrefab = prefab;
        _container = container;

        CreatePool(count);
    }

    //public MonobehObjectPooler(Transform container, int count, params T[] prefab)
    //{
    //    prefab.
    //    _container = container;
    //    _prefab = prefab;

    //    CreatePool(count);
    //}

    public T GetFreeMonobehObject()
    {
        if (HasFreeObject(out T prefab))
            return prefab;
        else return CreateObject(true);
        //else
        //{
        //    var fab = CreateObject();
        //}

        throw new System.Exception("There is no objects in pool");
    }

    private void CreatePool(int count)
    {
        _poolList = new List<T>();
        //_multiplePoolList = new List<T[]>();

        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var prefab = Object.Instantiate(_singlePrefab, _container);
        prefab.gameObject.SetActive(isActiveByDefault);
        _poolList.Add(prefab);
        return prefab;
        //T[] prefab = new T[_multiplePrefab.Length];
        //for (int i = 0; i < _multiplePrefab.Length; i++)
        //{
        //    prefab[i] = Object.Instantiate(_multiplePrefab[i], _container);
        //    prefab[i].gameObject.SetActive(false);
        //}
        //_multiplePoolList.Add(prefab);

        //return prefab[Random.Range(0, prefab.Length)];
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