using UnityEngine;

public class WeaponScrollButton : MonoBehaviour
{
    [SerializeField] private GameObject _scrollMenu;

    public void OpenScrollMenu()
    {
        _scrollMenu.SetActive(true);
    }

    public void CloseScrollMenu()
    {
        _scrollMenu.SetActive(false);
    }
}