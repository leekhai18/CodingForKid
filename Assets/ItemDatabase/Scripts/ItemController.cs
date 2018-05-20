                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : Singleton<ItemController>
{
    public GameObject gameController;
    public GameObject panelInformation;
    public GameObject panelWarning;
    public GameObject Panel;
    public GameObject _spriteSignal;
    public Text _text;
    private Item currentItem;
    public Text WarningText;
    public GameObject WarningSignal;
    public GameObject victoryPanel;
    public GameObject failedPanel;
    private bool signalCheck;
    public GameObject timeResult;
    public Image starResult;
    // Use this for initialization
    //function
    /*
      creat information panel
      fade out information panel
      destroy information panel
      setacive =false
      */
    void Start()
    {
        signalCheck = true;
    }
    //set gameobject location
    public void SetLocation(Vector3 loc)
    {
        Panel.transform.position = loc;
    }
    //update id- update information panel with item[ID]
    public void UpdateID(int ID)
    {

        Item item = ItemDataBase.GetItem(ID);
        currentItem = item;

        if (currentItem == null)
        {

        }
        else
        {

            _text.text = "" + currentItem.VietnameseDesc;
            _spriteSignal.GetComponent<Image>().sprite = currentItem.iconSprite;

            WarningText.text = _text.text;
            WarningSignal.GetComponent<Image>().sprite= currentItem.iconSprite; ;
        }
    }

    // Update is called once per frame
    void Update()
    { }
    //show information panel
    public void ShowWarningPanel(int ID)
    {
        UpdateID(ID);
        gameController.GetComponent<FadeController>().FadeIn();

    }
    public void ShowInformationPanel(int ID)
    {
        if (signalCheck == true)
        {
            UpdateID(ID);
            gameController.GetComponent<FadeController>().FadeIn();
            signalCheck = false;
        }
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
       gameController.GetComponent< FadeController>().FadeOut();
        StartCoroutine(DestroyInformationPanelAfter(gameController.GetComponent<FadeController>().Time));
        signalCheck = true;
    }
    public void ShowResultPanel(string str)
    {
        bool victory;
        if (str == "Victory")
            victory = true;
        else victory = false;
        if (victory == true)
            ShowVictoryPanel();
        else
            ShowFailedPanel();
    }
    public void ShowVictoryPanel()
    {
        timeResult.GetComponent<Text>().text=""+(GameManager.timeEnd - GameManager.timeBegin) + " s";

        starResult.sprite = LifeCount.Instance.star.sprite;
        failedPanel.SetActive(false);
        victoryPanel.SetActive(true);
    }
    public void ShowFailedPanel()
    {

        timeResult.GetComponent<Text>().text = "" + (GameManager.timeEnd - GameManager.timeBegin)+" s";
  
        victoryPanel.SetActive(false);
        StartCoroutine(WaittingLose(2));
    }
    IEnumerator WaittingLose(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        failedPanel.SetActive(true);

    }

}