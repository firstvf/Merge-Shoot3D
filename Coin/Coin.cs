using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private WaitForSeconds _lootTimer;
    private CoinIcon _destinationPoint;
    private bool _isAbleToMove;
    private MoneyBank _bank;
    private bool _isAbleToLoot;

    private void Awake()
    {
        _lootTimer = new WaitForSeconds(1f);
    }

    private void OnEnable()
    {
        StartCoroutine(MoveToCointIcon());
    }

    private void Start()
    {
        _isAbleToLoot = true;
    }

    private IEnumerator MoveToCointIcon()
    {
        yield return _lootTimer;

        if (_destinationPoint == null)
            _destinationPoint = CoinIcon.Singleton;
        _isAbleToMove = true;
    }

    public void Setup(Vector3 position)
    {
        transform.position = new Vector3(
            Random.Range(position.x - 0.25f, position.x + 0.25f),
            Random.Range(position.y+0.5f, position.y + 0.55f),
            position.z);
    }

    private void Update()
    {
        if (_isAbleToMove)
        {
            transform.position = Vector3.Lerp(transform.position, _destinationPoint.transform.position, 5f * Time.deltaTime);
            if (Vector3.Distance(transform.position, _destinationPoint.transform.position) < 0.2f)
                gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (_isAbleToLoot)
        {
            if (_bank == null)
                _bank = MoneyBank.Singleton;
            _bank.AddMoney();
        }
        _isAbleToMove = false;
    }
}