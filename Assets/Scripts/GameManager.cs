using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    GameObject car;
    CarBehaviour carBehaviour;

    List<Command> listCommands;
    Command currentCommand;
    int index;

    [SerializeField]
    GameObject containerEnd;


    // Use this for initialization
    void Start()
    {
        index = 0;
        listCommands = new List<Command>();
        carBehaviour = car.GetComponent<CarBehaviour>();
        currentCommand = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsBooted()
    {
        currentCommand = listCommands[0];
        return (listCommands[0].GetComponent<StartCommand>() != null);
    }

    public void ExecuteCommand()
    {
        if (currentCommand != null)
        {
            currentCommand.Controller(carBehaviour);
        }

        currentCommand = GetNextCommand();
    }

    public bool InitListCommand()
    {
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


    Command GetNextCommand()
    {
        index++;
        if (index < listCommands.Count)
            return listCommands[index];

        return null;
    }
}
