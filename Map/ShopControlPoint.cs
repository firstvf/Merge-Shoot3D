using UnityEngine;

public class ShopControlPoint : MonoBehaviour
{
    [SerializeField] private GameObject _battleInterface, _shopInterface;
    [SerializeField] private MapController _mapController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<Player>())
        {
            _mapController.ShopPoint();
            ShopPoint();
        }
    }

    private void ShopPoint()
    {
        _battleInterface.SetActive(false);
        _shopInterface.SetActive(true);
    }

    public void CloseShopPoint()
    {
        _shopInterface.SetActive(false);
        _battleInterface.SetActive(true);
        _mapController.ContinueMap();
    }
}