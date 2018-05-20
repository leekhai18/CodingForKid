using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HomeManager : MonoBehaviour {
    public GameObject loadingScene;
    public Slider slide;
    public Text text;
    public Text test;
    // Use this for initialization
    private void Awake()
    {
        slide.value = 0.5f;
    }
    void Start () {
       
    }

	// Update is called once per frame
	void Update () {
       
    }
    public void Onchanging()
    {
        test.text = "" + (int)(slide.value * 100) + "%";
    }
    public void Ready()
    {
        SceneManagerment.Instance.Load("SelectLevel");
    }
    public void Replay()
    {
        StartCoroutine(Loadreplay());
    }
    public void Quit()
    {

        Application.Quit();
    }
    public void BackToHome()
    {

        SceneManagerment.Instance.Load("GameHome");
    }
    public void LoadSceneLevel()
    {

        StartCoroutine(LoadYourAsyncScene());
    }
    IEnumerator LoadYourAsyncScene()
    {

        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex

        AsyncOperation asyncLoad = SceneManagerment.Instance.Load("SelectLevel");
        Debug.Log("On loading scene");
        loadingScene.SetActive(true);




        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {


            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            slide.value = progress;
            text.text =""+ progress * 100f + " %";
            yield return null;
        }
    }
    IEnumerator Loadreplay()
    {

        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex

        AsyncOperation asyncLoad = SceneManagerment.Instance.Load("Gameplay", "LevelSelected", LevelManager.SelectedStaticLevel.ToString());
            loadingScene.SetActive(true);


        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
               float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
                slide.value = progress;

                text.text = "" + progress * 100f + " %";
            yield return null;
        }
    }
}
