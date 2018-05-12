using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SignalInformationShowController : MonoBehaviour {
    public GameObject informationController;

    // Use this for initialization
    void Start () {
	}
    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            this.GetComponent<SignalInformationShowController>().informationController.GetComponent<ItemController>().updateID(this.GetComponent<IDcontroller>().ID);
            informationController.GetComponent<ItemController>().clickButtonNew();
        }
    }

    private void OnMouseExit()
    {
        informationController.GetComponent<ItemController>().clickButtonExit();
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
