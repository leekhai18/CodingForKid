using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
    }


    public void HideQuizBackground()
    {
        QuizManager.Instance.quizBackground.SetActive(false);
    }
}
