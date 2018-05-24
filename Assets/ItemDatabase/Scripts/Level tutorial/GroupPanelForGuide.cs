using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GroupPanelForGuide : MonoBehaviour {
    // Use this for initialization
    Animator animator;

    RectTransform rectTran;

    void Start () {
        rectTran = GetComponent<RectTransform>();

        GameObject UIOverLayout = GameObject.FindGameObjectWithTag("UIOverlayout");

        if (UIOverLayout)
        {
            this.transform.SetParent(UIOverLayout.transform);

            rectTran.localScale = new Vector3(1, 1, 1);

            rectTran.anchorMin = Vector2.zero;
            rectTran.anchorMax = Vector2.one;
            rectTran.pivot = new Vector2(0.5f, 0.5f);
            rectTran.sizeDelta = Vector2.zero;
            rectTran.localPosition = Vector2.zero;
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
