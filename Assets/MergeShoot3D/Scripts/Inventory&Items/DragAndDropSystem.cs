using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropSystem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        DragDropItemList.Instance.AddItemToList(_canvasGroup);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragDropItemList.Instance.DeactivateAllRaycastWhileDrag(_canvasGroup);
        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        _rectTransform.anchoredPosition = new Vector2(0, 0);
        DragDropItemList.Instance.ActiveAllRaycast();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}