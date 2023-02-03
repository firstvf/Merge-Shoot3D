using TMPro;
using UnityEngine;

public class MoneyBank : MonoBehaviour
{
    public static MoneyBank Instance { get; private set; }
    public uint Money { get; private set; }

    [SerializeField] private TextMeshProUGUI _moneyText;

    // TEST
    public bool IsTest = false;
    public int CheatValue;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Money = 100000;
        _moneyText.SetText(FormatText.FormatTextMoney(Money));
    }

    private void Update()
    {
        if (IsTest)
        {
            IsTest = false;
            AddMoney((uint)CheatValue);
        }
    }

    public void AddMoney(uint money)
    {
        Money += money;
        _moneyText.SetText(FormatText.FormatTextMoney(Money));
    }

    public void WithdrawMoney(uint money)
    {
        Money -= money;
        _moneyText.SetText(FormatText.FormatTextMoney(Money));
    }
}