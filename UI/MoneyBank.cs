using TMPro;
using UnityEngine;

public class MoneyBank : MonoBehaviour
{
    public static MoneyBank Instance { get; private set; }
    public ulong Money { get; private set; }

    [SerializeField] private TextMeshProUGUI _moneyText;

    private readonly string[] FORMAT_NAMES = { "", "K", "M", "B", "T" };

    // TEST
    public bool IsTest = false;
    public int CheatValue;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Money = 100000000;
        FormatTextMoney();
    }

    private void Update()
    {
        if (IsTest)
        {
            IsTest = false;
            AddMoney((ulong)CheatValue);
        }
    }

    public void AddMoney(ulong money)
    {
        Money += money;
        FormatTextMoney();
    }

    public void WithdrawMoney(ulong money)
    {
        Money -= money;
        FormatTextMoney();
    }

    private void FormatTextMoney()
    {
        var formatMoney = Money;
        int counter = 0;

        while (counter + 1 < FORMAT_NAMES.Length && formatMoney >= 1000)
        {
            formatMoney /= 1000;
            counter++;
        }

        _moneyText.SetText(formatMoney.ToString("#.##") + FORMAT_NAMES[counter]);
    }
}