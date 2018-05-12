using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GroupPanelForGuide : MonoBehaviour {
    // Use this for initialization
    Animator animator;

	void Start () {
        GameObject UIOverLayout = GameObject.FindGameObjectWithTag("UIOverlayout");

        if (UIOverLayout)
        {
            this.transform.SetParent(UIOverLayout.transform);
        }

        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GotItTarget()
    {
        animator.SetBool("IsGotItTarget", true);
    }

    public void CompletedStep1()
    {
        animator.SetBool("IsCompletedStep1", true);
    }

    public void CompletedStep2()
    {
        animator.SetBool("IsCompletedStep2", true);
    }

    public void CompletedLastStep()
    {
        animator.SetBool("IsCompletedLastStep", true);
    }
}
