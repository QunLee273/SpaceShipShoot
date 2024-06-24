using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : ShipMonoBehaviour, IDropHandler
{
   public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0) return;
        GameObject dropObj = eventData.pointerDrag;
        DragItem dragItem = dropObj.GetComponent<DragItem>();
        dragItem.SetRealParent(transform);
    }
}
