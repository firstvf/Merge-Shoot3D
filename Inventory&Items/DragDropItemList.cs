using System.Collections.Generic;
using UnityEngine;

public class DragDropItemList : MonoBehaviour
{
    public static DragDropItemList Singleton { get; private set; }

    private List<CanvasGroup> _canvasGrpList;

    private void Awake()
    {
        _canvasGrpList = new List<CanvasGroup>();
        Singleton = this;
    }

    public void AddItemToList(CanvasGroup canv)
    {
        _canvasGrpList.Add(canv);
    }

    public void RemoveItemFromList(CanvasGroup canv)
    {
        _canvasGrpList.Remove(canv);
    }

    public void DeactivateAllRaycastWhileDrag(CanvasGroup currentDragCanvas)
    {
        for (int i = 0; i < _canvasGrpList.Count; i++)
            if (_canvasGrpList[i] != currentDragCanvas)
                _canvasGrpList[i].blocksRaycasts = false;
    }

    public void ActiveAllRaycast()
    {
        for (int i = 0; i < _canvasGrpList.Count; i++)
            _canvasGrpList[i].blocksRaycasts = true;
    }
}