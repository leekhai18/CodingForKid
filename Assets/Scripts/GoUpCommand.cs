using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUpCommand : Command
{

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Controller(CarBehaviour car)
    {
        car.GoUp();
    }
}
