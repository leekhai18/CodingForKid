using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationShowAndHide : Singleton<InformationShowAndHide>
{
    
    private Vector3 _beginLocation;
    private Vector3 _endLocation = new Vector3(Screen.width / 2, Screen.height / 2, 0);


    public Vector3 beginLocation
    {
        get
        {
            return _beginLocation;
        }

        set
        {
            _beginLocation = value;
        }
    }

    public Vector3 endLocation
    {
        get
        {
            return _endLocation;
        }

        set
        {
            _endLocation = value;
        }
    }
   
    // Use this for initialization
   
 
    public void ShowInformationPanel(int ID)

    {

        ItemController.Instance.Panel.SetActive(true);
        //...
         ItemController.Instance.ShowInformationPanel(ID);
        
    }




    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
