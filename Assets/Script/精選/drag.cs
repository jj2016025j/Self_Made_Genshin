using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class dragdrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform RectTransform;
    [SerializeField] private CanvasGroup CanvasGroup;

    public Transform origenalparent;
    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        CanvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        origenalparent = transform.parent;
        transform.SetParent(transform.parent.parent);
        Debug.Log("OnBeginDrag" + eventData);
        CanvasGroup.alpha = 0.6f;
        CanvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag" + eventData.pointerCurrentRaycast.gameObject.name);
        //RectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;//這兩個一樣
        transform.position = eventData.position;//這兩個一樣
    }
    public void OnEndDrag(PointerEventData eventData)
    {

        Debug.Log("OnEndDrag" + eventData);
        CanvasGroup.alpha = 1f;

        GameObject eventDatagameobject = eventData.pointerCurrentRaycast.gameObject;
        if (eventDatagameobject.tag == "item")
        {
            transform.SetParent(eventDatagameobject.transform.parent);
            transform.position = eventDatagameobject.transform.position;
            eventDatagameobject.transform.position = origenalparent.position;
            eventDatagameobject.transform.SetParent(origenalparent);
            CanvasGroup.blocksRaycasts = true;
            return;
        }
        if (eventDatagameobject.tag != "slot" & eventDatagameobject.tag != "item")
        {
            transform.SetParent(origenalparent.transform);
            transform.position = origenalparent.transform.position;
            CanvasGroup.blocksRaycasts = true;
            return;
        }
        transform.SetParent(eventDatagameobject.transform);
        transform.position = eventDatagameobject.transform.position;
        CanvasGroup.blocksRaycasts = true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown" + eventData);
    }
    public void OnDrop(PointerEventData eventData)
    {

    }
}
public class itemslot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData);
        if (eventData.pointerDrag != null)
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
    }
}