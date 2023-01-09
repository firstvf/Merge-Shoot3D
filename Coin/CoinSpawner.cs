using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner Singleton { get; private set; }

    [SerializeField] private GameObject _coin;

    private CoinPooler _pooler;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        _pooler = new CoinPooler(_coin, 4, transform);
    }

    public void CreateCoinFromPool(Vector3 position)
    {
        var coin = _pooler.GetFreeCoin();
        coin.Setup(new Vector3(position.x, position.y + 1, position.z));
    }
}