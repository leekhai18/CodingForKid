using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRightCommand : Command
{
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Controller(CarBehaviour car)
    {
        car.TurnRight();
    }
}
