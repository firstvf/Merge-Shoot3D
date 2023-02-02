using UnityEngine;

public class LayoutGroupSettings : MonoBehaviour
{
    [SerializeField] private BuyWeaponButton[] _weaponBuyButtons;
    [SerializeField] private GameObject[] _closedLock;


    private void Start()
    {
        SetWeaponSettings();
    }

    private void OnEnable()
    {
        UnlockWeaponInLayoutGroup();
    }

    public void UnlockWeaponInLayoutGroup()
    {
        var unlockCount = 0;
        for (int i = 1; i <= Player.Instance.CurrentWeaponLevel; i++)
            if (i % 2 == 0)
                unlockCount++;

        for (int i = 0; i < unlockCount + 1; i++)
            if (_closedLock[i].activeInHierarchy)
                _closedLock[i].SetActive(false);
    }

    public void SetWeaponSettings()
    {

        for (int i = 0; i < _weaponBuyButtons.Length; i++)
        {
            _weaponBuyButtons[i].SetButtonSettings(i);
        }
    }
}