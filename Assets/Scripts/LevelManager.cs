using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    [SerializeField]
    List<Image> listLevels;

    [SerializeField]
    Sprite spriteLevelSeleted;

    [SerializeField]
    Sprite spriteHomeSeleted;

    [SerializeField]
    Sprite spriteShopSeleted;

    bool isSelected;

    int levelSelected;

    // Use this for initialization
    void Start () {
        isSelected = false;
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
        levelSelected = i - 1;
        listLevels[levelSelected].sprite = spriteLevelSeleted;
        isSelected = true;
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
}
