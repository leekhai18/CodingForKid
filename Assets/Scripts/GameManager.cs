using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class GameManager : Singleton<GameManager>
{
    public static int numberOfLevel;
    public float countTime;
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
    private void Awake()
    {
        int levelSelected = Int32.Parse(SceneManagerment.Instance.GetParam("LevelSelected"));
        Transform transformOfMap = GameObject.FindGameObjectWithTag("Map").transform;
        
        Instantiate(listLevels[levelSelected], transformOfMap);
    }
    
    // Use this for initialization
    void Start()
    {
        countTime = 10;
        timeEnd = 0;
        timeBegin = 0;
        index = 0;
        listCommands = new List<Command>();
        carBehaviour = car.GetComponent<CarBehaviour>();
        currentCommand = null;
        beginX = containerEnd.transform.position.x;
        numberOfLevel = listLevels.ToArray().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBegin != 0 && timeEnd == 0)
        {
            if(Time.time-timeBegin<=countTime)
            carBehaviour.clock.text = (Time.time - timeBegin).ToString()+" s";
            if (Time.time - timeBegin > countTime)
                EndGame("Failed");
        }
        if (timeEnd - timeBegin >= countTime)
        {
            carBehaviour.clock.text = (Time.time - timeBegin).ToString();

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
        if(LevelManager.Instance.GetLevel() + 1>LevelManager.Instance.CountListOfMap())      
            LevelManager.Instance.UpdateLevel(0);
        else
        LevelManager.Instance.UpdateLevel(LevelManager.Instance.GetLevel()+1);
    }
    public void EndGame(string str)
    {
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
 
}
