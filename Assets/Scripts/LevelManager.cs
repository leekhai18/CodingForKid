using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelManager : Singleton<LevelManager>
{
    public static int countOfLevel = 0;
    public static int SelectedStaticLevel;
    public Text text;

    // bool isSelected;

    int levelSelected;
    public GameObject loadingScene;
    public Slider slide;
    // Use this for initialization
    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        int numOfLevel = this.transform.childCount;
        for (int i = 0; i < numOfLevel; i++)
        {
            if (i < currentLevel)
            {
                transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                transform.GetChild(i).gameObject.GetComponent<Button>().enabled = true;
            }
            else
            {
                transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
                transform.GetChild(i).gameObject.GetComponent<Button>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SelectedLevel(int i)
    {
        AudioManager.Instance.Play("ButtonClick");

        try
        {
            levelSelected = i;
        }
        catch (Exception)
        {
            levelSelected = 0;
        }

        StartCoroutine(LoadYourAsyncScene());
        SelectedStaticLevel = levelSelected;
    }

    public void UpdateLevel(int i)
    {
        {         
            try
            {
                countOfLevel = GameManager.Instance.CountList();
                levelSelected = i;
            }
            catch (Exception)
            {
                levelSelected = 0;
            }

            StartCoroutine(LoadYourAsyncScene());
            SelectedStaticLevel = levelSelected;
        }
    }

    IEnumerator LoadYourAsyncScene()
    {


        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex

        AsyncOperation asyncLoad = SceneManagerment.Instance.Load("Gameplay", "LevelSelected", levelSelected.ToString());
        try
        {
            loadingScene.SetActive(true);


        }
        catch (Exception)
        {

        }

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            try
            {
                float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
                slide.value = progress;

                text.text = (int)(progress * 100f) + " %";
            }
            catch (Exception)
            { }


            yield return null;
        }
    }
    public int GetLevel()
    {
        return SelectedStaticLevel;
    }
}
