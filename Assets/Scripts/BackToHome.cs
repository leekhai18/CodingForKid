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

        AudioManager.Instance.Play("ButtonClick");

        SceneManager.LoadScene("GameHome");
        
    }
    public void ReturnToSelectLevel()
    {
        AudioManager.Instance.Play("ButtonClick");

        SceneManagerment.Instance.Load("SelectLevel");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
