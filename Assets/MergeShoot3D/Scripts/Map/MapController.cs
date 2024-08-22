using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera, _shopCamera;
    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _canvasObject;

    private PlayerAnimationController _playerAnimationController;
    private List<Enemy> _enemyList;
    private WaitForSeconds _checkerTimer;
    private bool _isAbleToMoveMap;
    private Coroutine _mapCoroutine;

    private void Start()
    {
        if (!_canvasObject.activeInHierarchy)
            _canvasObject.SetActive(true);
        _checkerTimer = new WaitForSeconds(0.5f);
        _enemyList = EnemyTargetList.Instance.GetList();
        _playerAnimationController = Player.Instance.GetComponent<PlayerAnimationController>();
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
        _mainCamera.gameObject.SetActive(false);
        _shopCamera.gameObject.SetActive(true);
        _character.transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    public void ContinueMap()
    {
        _mapCoroutine = StartCoroutine(CheckEnemyOnMap());
        _shopCamera.gameObject.SetActive(false);
        _mainCamera.gameObject.SetActive(true);
        _character.transform.rotation = Quaternion.identity;
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
        if (transform.position.x <= -68)
            transform.position = new Vector3(74, 0, 0);
    }

    private void OnApplicationQuit()
    {
        SaveSystem.SaveGame();
    }
}