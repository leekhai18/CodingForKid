using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeHints : MonoBehaviour {
    private float time;
    private bool check = false;
    private void Start()
    {
        time = Time.time;
    }

    private void Update()
    {
        if (this.GetComponent<Transform>().localScale.x >= 0.1)
        {

            if (this.GetComponent<Transform>().localScale.x == 0.1)
                check = !check;
            if (check == true)
            {
                this.GetComponent<Transform>().localScale -= new Vector3(Time.deltaTime, Time.deltaTime, 0);
            }
        }
        else if (this.GetComponent<Transform>().localScale.x <= 0.5)
        {
            if (this.GetComponent<Transform>().localScale.x == 0.5)
                check = !check;
            if (check == false)
            {
                this.GetComponent<Transform>().localScale += new Vector3(Time.deltaTime, Time.deltaTime, 0);
            }
        }

    }
}
