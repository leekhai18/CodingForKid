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
    //function
    /*
      creat information panel
      fade out information panel
      destroy information panel
      setacive =false
      */
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword //???
    private void Awake()
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword //????
    {
        Panel.SetActive(true);
        gameController.GetComponent<FadeController>().FadeOut();
        StartCoroutine(DestroyInformationPanelAfter(0f));
        Panel.SetActive(false);

    }
    void Start()
    {

        //how to fix this shit man- need a different wave
        //need to hide this panel when we already started for first time fade out-if not- panel willfade in with time lerp=0
        //
    }
    //set gameobject location
    public void SetLocation(Vector3 loc)
    {
        Panel.transform.position = loc;
    }
    //update id- update information panel with item[ID]
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
    { }
    //show information panel
    public void ShowInformationPanel(int ID)
    {
        _btnExit.SetActive(true);
        UpdateID(ID);
        gameController.GetComponent<FadeController>().FadeIn();
    }
    //function delay destroy information panel with courotine
    IEnumerator DestroyInformationPanelAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);


        Panel.SetActive(false);
    }
    //hide information panel
    public void HideInformationPanel()
    {
        Debug.Log("Hide information sau khoang thoi gian = " + gameController.GetComponent<FadeController>().time);
        gameController.GetComponent<FadeController>().FadeOut();
        StartCoroutine(DestroyInformationPanelAfter(gameController.GetComponent<FadeController>().time));

    }

}