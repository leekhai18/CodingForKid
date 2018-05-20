using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void ReTurnToHome()
    {
        SceneManagerment.Instance.Load("GameHome");
        
    }
    public void ReturnToSelectLevel()
    {
        SceneManagerment.Instance.Load("SelectLevel");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
