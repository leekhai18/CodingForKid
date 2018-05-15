using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SignalInformationShowController : MonoBehaviour
{
    public int ID;
    // Use this for initialization
    void Start()
    {
        Item item = ItemDataBase.GetItem(ID);
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
        InformationShowAndHide.Instance.beginLocation = Input.mousePosition;
        InformationShowAndHide.Instance.ShowInformationPanel(ID);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
