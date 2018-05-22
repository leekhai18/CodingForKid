using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ChooseSkin : MonoBehaviour {
    [SerializeField]
    GameObject listCar;

    float countdown;
    bool isAvailability;
    int numberSkin;

	// Use this for initialization
	void Start () {
        isAvailability = true;
        countdown = 0;
        numberSkin = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (isAvailability == false)
        {
            countdown += Time.deltaTime;

            if (countdown > 1)
            {
                isAvailability = true;
                countdown = 0;
            }
        }
	}

    public void NextCar()
    {
        AudioManager.Instance.Play("ButtonClick");

        if (isAvailability)
        {
            if (listCar.transform.position.x > -38)
                listCar.transform.DOMoveX(listCar.transform.position.x - 10.4f, 1);

            isAvailability = false;

            numberSkin++;
        }
    }

    public void PreviousCar()
    {
        AudioManager.Instance.Play("ButtonClick");

        if (isAvailability)
        {
            if (listCar.transform.position.x < 29)
                listCar.transform.DOMoveX(listCar.transform.position.x + 10.4f, 1);

            isAvailability = false;

            numberSkin--;
        }
    }

    public void ChooseCar()
    {
        AudioManager.Instance.Play("ButtonClick");
        // Turn back choose Level
        // Save playerPref
        PlayerPrefs.SetInt("SkinNumber", numberSkin);
       
        SceneManager.LoadScene("GameHome");

    }
  
  
    }

