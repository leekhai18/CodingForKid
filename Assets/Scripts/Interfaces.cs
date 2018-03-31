using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController<T>
{
    void Controller(T car);
}

public enum EState
{
    begin,
    end
}