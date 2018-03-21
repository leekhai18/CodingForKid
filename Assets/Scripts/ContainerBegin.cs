using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBegin : MonoBehaviour
{
    [SerializeField] List<Slot> slots;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        for (int i = 0; i < slots.Count; i++)
        {
        }
    }


   

}
