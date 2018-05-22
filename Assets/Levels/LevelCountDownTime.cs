using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCountDownTime : Singleton<LevelCountDownTime> {
    public float countTime;
	// Use this for initialization
	void Start () {

        GameManager.countTime = countTime;
       GameManager.Instance.clock.GetComponent<Text>().text = "" + countTime + " Seconds";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
