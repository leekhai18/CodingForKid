using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    GameObject car;
    CarBehaviour carBehaviour;

    List<Command> listCommands;
    Command currentCommand;
    int index;

    public GameObject containerEnd;
    float beginX;

    public GameObject containerCmdHandling;


    // Use this for initialization
    void Start()
    {
        index = 0;
        listCommands = new List<Command>();
        carBehaviour = car.GetComponent<CarBehaviour>();
        currentCommand = null;
        beginX = containerEnd.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

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
            carBehaviour.Stop();
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
}
