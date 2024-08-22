using UnityEngine;

public class CoinIcon : MonoBehaviour
{
    public static CoinIcon Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}