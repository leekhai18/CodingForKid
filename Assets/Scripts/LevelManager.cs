using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelManager :Singleton<LevelManager> {
    public static int countOfLevel=0;
    public static int SelectedStaticLevel;
    public Text text;

    // bool isSelected;

    int levelSelected;
    public GameObject loadingScene;
    public Slider slide;
    // Use this for initialization
    void Start () {
      //  isSelected = false;
       
	}
	
	// Update is called once per frame
	void Update () {
        if (levelSelected != 0)
            SelectedStaticLevel= levelSelected;
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
            //    isSelected = true;
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

          //  isSelected = false;
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
