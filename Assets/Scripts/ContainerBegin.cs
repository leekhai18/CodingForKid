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
            GameObject obj = EasyObjectPool.instance.GetObjectFromPool(EasyObjectPool.instance.poolInfo[i].poolName, slots[i].transform.position, Quaternion.identity);
            obj.transform.SetParent(slots[i].transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


   

}
