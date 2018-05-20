using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class GameManager : Singleton<GameManager>
{
    public GameObject loadingScene;
    public int numberOfStar = 3;
    public Slider slide;
    public Text text;
    public GameObject clock;
    public GameObject star;
    public static float countTime;
    public static float timeEnd;
    public static float timeBegin;
    [SerializeField]
    GameObject car;
    CarBehaviour carBehaviour;

    List<Command> listCommands;
    Command currentCommand;
    int index;

    public GameObject containerEnd;
    float beginX;

    public GameObject containerCmdHandling;

    [SerializeField]
    List<GameObject> listLevels;
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
    private void Awake()
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
    {
        int levelSelected = Int32.Parse(SceneManagerment.Instance.GetParam("LevelSelected"));

        Transform transformOfMap = GameObject.FindGameObjectWithTag("Map").transform;
        
        Instantiate(listLevels[levelSelected], transformOfMap);
        //
        LevelManager.countOfLevel= listLevels.ToArray().Length; 
    }
    
    // Use this for initialization
    void Start()
    {
        countTime = 10;
        clock.GetComponent<Text>().text = "" + countTime + " Seconds";
        timeEnd = 0;
        timeBegin = 0;
        index = 0;
        listCommands = new List<Command>();
        carBehaviour = car.GetComponent<CarBehaviour>();
        currentCommand = null;
        beginX = containerEnd.transform.position.x;
        LevelManager.countOfLevel = listLevels.ToArray().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBegin != 0 && timeEnd == 0)
        {

            clock.GetComponent<Text>().text = (countTime - (Time.time - timeBegin)).ToString("0.0")+" s";
            if (Time.time - timeBegin > countTime)
                EndGame("Failed");
        }
        if (timeEnd - timeBegin == countTime)
        {
            clock.GetComponent<Text>().text = (countTime-( Time.time - timeBegin)).ToString("0.0")+" s";

            EndGame("Failed");
        }
        if(numberOfStar==3)
        {
            LifeCount.Instance.star.GetComponent<Image>().sprite = LifeCount.Instance.threeStar.GetComponent<Image>().sprite;
        }
        else if(numberOfStar==2)
        {

            LifeCount.Instance.star.GetComponent<Image>().sprite = LifeCount.Instance.twoStar.GetComponent<Image>().sprite;
        }
            else if(numberOfStar==1)
        {

            LifeCount.Instance.star.GetComponent<Image>().sprite = LifeCount.Instance.oneStar.GetComponent<Image>().sprite;
        }
            else if(numberOfStar==0)
        {
            EndGame("Failed");
        }
    }

    public bool IsBooted()
    {
        if (listCommands.Count > 0)
        {
            currentCommand = listCommands[0];
            return (listCommands[0].GetComponent<StartCommand>() != null);
        }

        return false;
    }

    public void ExecuteCommand()
    {
        if (currentCommand != null)
        {
            currentCommand.Controller(carBehaviour);
            EffectChoosing();

            if (currentCommand.transform.parent.position.x > 676)
            {
                Backward(90, 0.8f);
            }
        }
        else
        {
            // carBehaviour.Stop();
            carBehaviour.Run();
        }
    }

    public bool InitListCommand()
    {
        TurnBackBeginPositionX();

        Transform trans;
        foreach (var item in containerEnd.transform)
        {
            trans = item as Transform;
            if (trans.transform.childCount > 0)
            {
                listCommands.Add(trans.transform.GetChild(0).gameObject.GetComponent<Command>());
            }
        }

        return true;
    }


    public void NextCommand()
    {
        EffectExecuteDone();

        index++;
        if (index < listCommands.Count)
            currentCommand = listCommands[index];
        else
            currentCommand = null;
    }

    void EffectChoosing()
    {
        currentCommand.transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.5f);
    }

    void EffectExecuteDone()
    {
        if (currentCommand != null)
        {
            currentCommand.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
            currentCommand.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
        }
    }

    public void Backward(float distance, float duration)
    {
        containerEnd.transform.DOMoveX(containerEnd.transform.position.x - distance, duration);
    }

    public void Forward(float distance, float duration)
    {
        containerEnd.transform.DOMoveX(containerEnd.transform.position.x + distance, duration);
    }

    public void TurnBackBeginPositionX()
    {
        containerEnd.transform.DOMoveX(beginX, 0.15f);
    }
  public void Replay()
    {
        Debug.Log("\replay level" + LevelManager.Instance.GetLevel());
        LevelManager.Instance.UpdateLevel(LevelManager.Instance.GetLevel());
    }
    public void NextLevel()
    {
        LoadSceneNextLevel();
    }
    public void EndGame(string str)
    {
    //   QuizManager.Instance. quizPannel.SetActive(true);
    //    QuizManager.Instance.quizBackground.SetActive(true);
        ItemController.Instance.ShowResultPanel(str);
        if (str == "Victory")
        {
            StartCoroutine(WaitingWin(5));
        }
        else
            StartCoroutine(WaitingLose(5));
    }
    IEnumerator WaitingWin(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        NextLevel();

    }
    IEnumerator  WaitingLose(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManagerment.Instance.Load("GameOver");
    }
    public void ReturnToLevelSelect()
    {
        SceneManagerment.Instance.Load("SelectLevel");
    }
    public void ReturnToHome()
    {
        SceneManagerment.Instance.Load("GameHome");

    }
    public int CountList()
    {
        return listLevels.ToArray().Length;
    }
    public void LoadSceneNextLevel()
    {
        LevelManager.SelectedStaticLevel++;
        StartCoroutine(LoadYourAsyncScene());
    }
    IEnumerator LoadYourAsyncScene()
    {

        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex
       
        AsyncOperation asyncLoad = SceneManagerment.Instance.Load("Gameplay", "LevelSelected",LevelManager.SelectedStaticLevel.ToString());
        Debug.Log("On loading scene");
        loadingScene.SetActive(true);




        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {


            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            slide.value = progress;
            text.text = "" + progress * 100f + " %";
            yield return null;
        }
    }
}
