using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;

public class ContainerBegin : MonoBehaviour
{
    [SerializeField] List<Slot> slots;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            GameObject obj = EasyObjectPool.Instance.GetObjectFromPool(EasyObjectPool.Instance.poolInfo[i].poolName, slots[i].transform.position, Quaternion.identity);
            obj.transform.SetParent(slots[i].transform);
            obj.GetComponent<RectTransform>().localScale = Vector3.one;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


   

}
