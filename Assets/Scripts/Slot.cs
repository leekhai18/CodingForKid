using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MarchingBytes;

public class Slot : MonoBehaviour, IDropHandler
{
    [SerializeField] public string poolName;

    Slot begin;
    public Command item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject.GetComponent<Command>();
            }

            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            begin = DragHandler.itemBeginDragged.transform.parent.gameObject.GetComponent<Slot>();

            if (DragHandler.itemBeginDragged.GetCurrentState() != EState.end)
            {
                EasyObjectPool.instance.GetObjectFromPool(begin.poolName, begin.transform.position, Quaternion.identity)
                    .transform.SetParent(begin.transform);
            }

            DragHandler.itemBeginDragged.transform.SetParent(transform);
            DragHandler.itemBeginDragged.SetState(EState.end);

            poolName = begin.poolName;
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
