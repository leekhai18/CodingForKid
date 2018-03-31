using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Command itemBeginDragged;
    Vector3 startPosition;
    Transform startParent;


    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeginDragged = gameObject.GetComponent<Command>();
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {          
            if (itemBeginDragged.GetCurrentState() == EState.begin)
                transform.DOMove(startPosition, 0.2f);
            else
                Debug.Log("BUMMMMMMMMMMMMMMMMMM");
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
