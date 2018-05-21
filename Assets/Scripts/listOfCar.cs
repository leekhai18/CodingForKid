using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listOfCar : Singleton<listOfCar> {
    public Sprite[] carSkins;
    private static bool created = false;
    // Use this for initialization
    void Start () {
        if (!created)
        {
            //hello ward

            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
