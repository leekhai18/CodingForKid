using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager :Singleton<LevelManager> {
    public  int numberOfLevel;
     public static int SelectedStaticLevel;
    [SerializeField]
    List<Image> listLevels;

    [SerializeField]
    Sprite spriteLevelSeleted;

    [SerializeField]
    Sprite spriteHomeSeleted;

    [SerializeField]
    Sprite spriteShopSeleted;

    bool isSelected;

    public int levelSelected;

    // Use this for initialization
    void Start () {
        isSelected = false;
        numberOfLevel = GameManager.numberOfLevel;
	}
	
	// Update is called once per frame
	void Update () {
        if (isSelected)
        {
            // Use a coroutine to load the Scene in the background
            StartCoroutine(LoadYourAsyncScene());
            isSelected = false;
        }

    }

    public void SelectedLevel(int i)
    {

      //  if (i <= GameManager.numberOfLevel)
        {
            levelSelected = i;

            SelectedStaticLevel = levelSelected;
            listLevels[levelSelected - 1].sprite = spriteLevelSeleted;
            isSelected = true;
        }
    }
    public void UpdateLevel(int i)
    {
        {
            levelSelected = i;

            isSelected = true;
            StartCoroutine(LoadYourAsyncScene());
            isSelected = false;

            SelectedStaticLevel = levelSelected;
        }
    }
    
    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex

        AsyncOperation asyncLoad = SceneManagerment.Instance.Load("Gameplay", "LevelSelected", levelSelected.ToString());

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    public int GetLevel()
    {
        return SelectedStaticLevel;
    }
    public int CountListOfMap()
    {
        return 3;
    }

}
