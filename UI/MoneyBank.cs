using TMPro;
using UnityEngine;

public class MoneyBank : MonoBehaviour
{
    public static MoneyBank Singleton { get; private set; }
    public int Money { get; private set; }

    [SerializeField] private TextMeshProUGUI _moneyText;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        Money = 9999999;
        _moneyText.SetText(Money.ToString());
    }

    public void AddMoney()
    {
        Money += 5;
        _moneyText.SetText(Money.ToString());
    }

    public void WithdrawMoney(int money)
    {
        Money -= money;
        _moneyText.SetText(Money.ToString());
    }
}