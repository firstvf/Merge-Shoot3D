using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner Instance { get; private set; }

    [SerializeField] private Coin _coin;

    private MonobehObjectPooler<Coin> _pooler;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _pooler = new MonobehObjectPooler<Coin>(_coin, transform, 10);
    }

    public void CreateCoinFromPool(Vector3 position)
    {
        var coin = _pooler.GetFreeMonobehObject();
        coin.Setup(new Vector3(position.x, position.y + 1, position.z));
    }
}