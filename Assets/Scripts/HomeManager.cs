using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HomeManager : MonoBehaviour {
    public GameObject loadingScene;
    public Slider slide;
    public Text text;

    // Use this for initialization
    private void Awake()
    {
      
        slide.value = 0;
    }
    void Start () {
        if (!AudioManager.Instance.IsPlaying("Theme"))
            AudioManager.Instance.Play("Theme");
    }

    // Update is called once per frame
    void Update () {

    }

    public void Ready()
    { 
        SceneManagerment.Instance.Load("SelectLevel");
    }
    public void Replay()
    {
        AudioManager.Instance.Play("ButtonClick");

        SceneManagerment.starOfCounting = 3;
        Debug.Log("set starOfCounting =3 tai homescene");
        StartCoroutine(Loadreplay());
    }
    public void Quit()
    {

        Application.Quit();
    }
    public void BackToHome()
    {
        AudioManager.Instance.Play("ButtonClick");

        SceneManagerment.starOfCounting = 3;
        SceneManager.LoadScene("GameHome");
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
        loadingScene.SetActive(true);




        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            slide.value = progress;
            text.text = (int)(progress * 100f) + " %";

            Debug.Log(text.text);
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

            text.text = (int)(progress * 100f) + " %";
            yield return null;
        }
    }
    IEnumerator LoadSkins()
    {

        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex

        float fadeTime = GameObject.Find("FADE").GetComponent<Fading>().BeginFade(1);
        
        AsyncOperation asyncLoad = SceneManagerment.Instance.Load("Skins");
        loadingScene.SetActive(true);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            slide.value = progress;
            text.text = (int)(progress * 100f) + " %";
            yield return null;
        }
    }
    public void LoadSceneSkins()
    {

        StartCoroutine(LoadSkins());
    }
   
}

