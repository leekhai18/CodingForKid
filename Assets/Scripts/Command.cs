using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Command : MonoBehaviour
{
    EState currentState = EState.begin;

    [SerializeField] GameObject effectReturn;

    public virtual void Controller(CarBehaviour car)
    {
    }

    public void SetState(EState state)
    {
        currentState = state;
    }

    public EState GetCurrentState()
    {
        return currentState;
    }


}

