using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void ReTurnToHome()
    {
        Debug.Log("Return to hom from 404 page");
        GameManager.Instance.ReturnToHome();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
