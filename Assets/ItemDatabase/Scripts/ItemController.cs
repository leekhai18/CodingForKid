using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : Singleton<ItemController>
{ 
public GameObject gameController;
    public GameObject Panel;
    public GameObject _spriteSignal;
    public Text _text;
     public GameObject _btnExit;
    private int numberOfID;
    private Item currentItem;
    // Use this for initialization
    void Start()
    {
        
        //how to fix this shit man- need a different wave
        //need to hide this panel when we already started for first time fade out-if not- panel willfade in with time lerp=0
        //
        Panel.SetActive(true);
        gameController.GetComponent<FadeController>().FadeOut();
        StartCoroutine(DestroyInformationPanelAfter(0f));
        Panel.SetActive(false);
        //
    }
    public void SetLocation(Vector3 loc)
    {
        Panel.transform.position = loc;
    }
    public void UpdateID(int ID)
    {
        Debug.Log("class itemcontroller + ham update id = " + ID);
        Item item = ItemDataBase.GetItem(ID);
        currentItem = item;

        if (currentItem == null)
        {

        }
        else
        {
            _text.text = "" + currentItem.VietnameseDesc;
            _spriteSignal.GetComponent<Image>().sprite = currentItem.iconSprite;

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
 
    public void ShowInformationPanel(int ID)
    {
        //...
        _btnExit.SetActive(true);
        UpdateID(ID);
        gameController.GetComponent<FadeController>().FadeIn();
      

    }

    IEnumerator DestroyInformationPanelAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);


        Panel.SetActive(false);
    }

    public void HideInformationPanel()
    {
        Debug.Log("Hide information sau khoang thoi gian = " + gameController.GetComponent<FadeController>().time);
        gameController.GetComponent<FadeController>().FadeOut();
        StartCoroutine(DestroyInformationPanelAfter(gameController.GetComponent<FadeController>().time));
        
    }
    
}