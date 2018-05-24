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
            if (listCar.transform.localPosition.x > -2500 && listCar.transform.localPosition.x < 3000)
            {
                listCar.transform.DOLocalMoveX(listCar.transform.localPosition.x + 800, 1);

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
            if (listCar.transform.localPosition.x < 3200 && listCar.transform.localPosition.x > -2400)
            {
                listCar.transform.DOLocalMoveX(listCar.transform.localPosition.x - 800, 1);

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

