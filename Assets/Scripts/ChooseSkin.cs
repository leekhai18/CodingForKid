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
        numberSkin = 0;
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
            if (listCar.transform.position.x > -28 && listCar.transform.position.x < 24)
            {
                listCar.transform.DOMoveX(listCar.transform.position.x + 7.37f, 1);

                isAvailability = false;

                numberSkin++;
            }
        }
    }

    public void PreviousCar()
    {
        AudioManager.Instance.Play("ButtonClick");

        if (isAvailability)
        {
            if (listCar.transform.position.x < 25 && listCar.transform.position.x > -27)
            {
                listCar.transform.DOMoveX(listCar.transform.position.x - 7.37f, 1);

                isAvailability = false;

                numberSkin--;
            }
        }
    }

    public void ChooseCar()
    {
        AudioManager.Instance.Play("ButtonClick");

        PlayerPrefs.SetInt("SkinNumber", numberSkin);

        SceneManager.LoadScene("GameHome");
    }
  
  
}

