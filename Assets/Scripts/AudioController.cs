using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public AudioSource audioS;
	// Use this for initialization
	void Start () {
		
	}
    private void Awake()
    {
        audioS = gameObject.GetComponent<AudioSource>();
        audioS.clip = SceneManagerment.Instance.clickButton;
    }
    public void click()
    {
        audioS.Play();
        audioS.PlayOneShot(SceneManagerment.Instance.clickButton);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
