using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public GameObject gameController;
    public GameObject Panel;
    public int _signalID;
    public GameObject _spriteSignal;
    public Text _text;
    public Button _btnExit;
    private int numberOfID;
    
  //  public int sightBoardID=1;
   // public Sprite sp;
    // Use this for initialization
    void Start()
    {
        
        gameController.GetComponent<FadeController>().FadeOut();


    }
    public void updateID(int temp)
    {
        _signalID= temp;
    }

    // Update is called once per frame
    void Update()
    {
        //test
      

        
    }

    private void updateSignal()
    {
        Debug.Log("Xuat file hinh anh cua item " + _signalID);
        Item item = ItemDataBase.GetItem(_signalID);
        if (item==null)
        {
           
        }
        else
        {
            _text.text =""+ item.itemDesc;
            _spriteSignal.GetComponent<Image>().sprite = item.iconSprite;
            
        }
    }
    private void destroyPanel()
    {

        Panel.SetActive(false);
    }
    public void clickButtonNew()
    {

        Panel.SetActive(true);
     
        updateSignal();
        gameController.GetComponent<FadeController>().FadeIn();
        
    }public void clickButtonExit()
    {
        gameController.GetComponent<FadeController>().FadeOut();
        Invoke("destroyPanel",1);
        
    }
}