using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Ready()
    {
        SceneManagerment.Instance.Load("SelectLevel");
    }
    public void Replay()
    {
        GameManager.Instance.Replay();
    }
}
