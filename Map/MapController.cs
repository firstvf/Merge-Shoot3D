using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private PlayerAnimationController _playerAnimationController;
    private List<Enemy> _enemyList;
    private WaitForSeconds _checkerTimer;
    private bool _isAbleToMoveMap;
    private Coroutine _mapCoroutine;

    private void Start()
    {
        _checkerTimer = new WaitForSeconds(0.5f);
        _enemyList = EnemyTargetList.Singleton.GetList();
        _playerAnimationController = Player.Singleton.GetComponent<PlayerAnimationController>();
        _mapCoroutine = StartCoroutine(CheckEnemyOnMap());
    }

    private void Update()
    {
        if (_isAbleToMoveMap)
        {
            transform.position += Vector3.left * 0.1f;
            ResetMap();
        }
    }

    public void ShopPoint()
    {
        StopCoroutine(_mapCoroutine);
        _isAbleToMoveMap = false;
        _playerAnimationController.SetIdleTrigger();
    }

    public void ContinueMap()
    {
        _mapCoroutine = StartCoroutine(CheckEnemyOnMap());
    }

    private IEnumerator CheckEnemyOnMap()
    {
        while (true)
        {
            yield return _checkerTimer;

            if (_enemyList.Count == 0)
            {
                _playerAnimationController.SetRunTrigger();
                _isAbleToMoveMap = true;
            }
            else
            {
                _isAbleToMoveMap = false;
                _playerAnimationController.SetAimTrigger();
            }
        }
    }

    private void ResetMap()
    {
        if (transform.position.x <= -78)
            transform.position = new Vector3(34, 0, 0);
    }
}