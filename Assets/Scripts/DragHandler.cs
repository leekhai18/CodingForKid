using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using MarchingBytes;

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

        if (itemBeginDragged.GetCurrentState() == EState.end)
        {
            Debug.Log("Return pool " + itemBeginDragged.GetComponentInParent<Slot>().poolName);
            itemBeginDragged.transform.SetParent(GameManager.Instance.containerCmdHandling.transform);
            startParent = GameManager.Instance.containerCmdHandling.transform;
        }
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
            {
                transform.DOMove(startPosition, 0.2f);
            }
            else 
            {
                itemBeginDragged.SetState(EState.begin);
                itemBeginDragged.transform.SetParent(EasyObjectPool.Instance.transform);
                EasyObjectPool.Instance.ReturnObjectToPool(itemBeginDragged.gameObject);
            }
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
