using UnityEngine;

public class CoinIcon : MonoBehaviour
{
    public static CoinIcon Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }
}