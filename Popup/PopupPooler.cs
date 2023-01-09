using System.Collections.Generic;
using UnityEngine;

public class PopupPooler
{
    private GameObject _prefab;
    private List<GameObject> _poolList;
    private Transform _container;

    public PopupPooler(GameObject prefab, int count, Transform container)
    {
        _container = container;
        _prefab = prefab;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _poolList = new List<GameObject>();

        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private DamagePopup CreateObject(bool isActiveByDefault = false)
    {
        var prefab = Object.Instantiate(_prefab, _container.position, Quaternion.identity, _container);
        prefab.SetActive(isActiveByDefault);
        _poolList.Add(prefab);
        return prefab.GetComponent<DamagePopup>();
    }

    private bool HasFreePopup(out DamagePopup popup)
    {
        foreach (var prefab in _poolList)
            if (!prefab.activeInHierarchy)
            {
                popup = prefab.GetComponent<DamagePopup>();
                prefab.SetActive(true);
                return true;
            }
        popup = null;
        return false;
    }

    public DamagePopup GetFreePopup()
    {
        if (HasFreePopup(out var prefab))
            return prefab;
        else
            return CreateObject(true);

        throw new System.Exception("There is no popup in pool");
    }
}