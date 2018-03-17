using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public float verlocityX = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetPosiotion(verlocityX);
	}

    void SetPosiotion(float x) {
        transform.position = new Vector3(transform.position.x + verlocityX*Time.deltaTime,  transform.position.y, transform.position.z);   
    }
}
