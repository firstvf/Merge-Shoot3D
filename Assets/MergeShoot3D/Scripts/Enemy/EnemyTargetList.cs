using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetList : MonoBehaviour
{
    public static EnemyTargetList Instance { get; private set; }
    private List<Enemy> _enemyList;

    private void Awake()
    {
        _enemyList = new List<Enemy>();
        Instance = this;
    }

    public List<Enemy> GetList() => _enemyList;    

    public void AddToEnemyList(Enemy enemy)
    {
        _enemyList.Add(enemy);
    }

    public void RemoveFromEnemyList(Enemy enemy)
    {
        _enemyList.Remove(enemy);
    }
}