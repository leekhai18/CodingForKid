﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SignalInformationShowController : MonoBehaviour {
    public int ID;
   // Use this for initialization
    void Start () {
        Debug.Log("Get component set sprite ID =" + ID);
        Item item = ItemDataBase.GetItem(ID);
        if (item == null)
            Debug.Log("Ko lay dc item - item null");
        GetComponent<SpriteRenderer>().sprite = item.itemSprite;
    }

    public Vector3 getLocation()
    {
        return transform.position;
    }
    //sau khi click vao - va panel hien ra van co the click vao cac panel khac trong khi information panel dang hien
    //fixed kkhong the click trong khi panel information con acctive
    private void OnMouseDown()
    {
        Debug.Log("Goi ham onmouse down");
        InformationShowAndHide.Instance.beginLocation = Input.mousePosition;
//        InformationShowAndHide.Instance.endLocation = new Vector3(Screen.width/2, Screen.height/2, 0);
        Debug.Log("Mouse down on");
        
        InformationShowAndHide.Instance.ShowInformationPanel(ID);
     }
    // Update is called once per frame
    void Update () {
	    
	}
}
