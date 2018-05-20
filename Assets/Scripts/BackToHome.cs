using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void ReTurnToHome()
    {
        SceneManager.LoadScene("GameHome");
        
    }
    public void ReturnToSelectLevel()
    {
        SceneManagerment.Instance.Load("SelectLevel");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
