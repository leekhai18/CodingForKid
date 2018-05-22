using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManagerment : Singleton<SceneManagerment> {
    private static bool created = false;
    public static float starOfCounting=3;
    public  AudioClip clickButton;
    public  AudioClip bgMusic;
    public  AudioClip gameOver;
    public AudioClip levelCompleted;
    public  AudioClip carRun;
    public  AudioClip carEngine;
    public  AudioClip gameWin;
    public AudioClip correct;
   
    // Use this for initialization
    void Start () {
        if (!created)
        {
            //hello ward

            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private Dictionary<string, string> parameters;

    public AsyncOperation Load(string sceneName, Dictionary<string, string> parameters = null)
    {
        this.parameters = parameters;
        return SceneManager.LoadSceneAsync(sceneName);
    }

    public AsyncOperation Load(string sceneName, string paramKey, string paramValue)
    {
        parameters = new Dictionary<string, string>
        {
            { paramKey, paramValue }
        };
        return SceneManager.LoadSceneAsync(sceneName);    
    }

    public Dictionary<string, string> getSceneParameters()
    {
        return parameters;
    }

    public string GetParam(string paramKey)
    {
        if (parameters == null) return "0";
        return parameters[paramKey];
    }

    public void SetParam(string paramKey, string paramValue)
    {
        if (parameters == null)
            parameters = new Dictionary<string, string>();

        parameters.Add(paramKey, paramValue);
    }
    public AsyncOperation Load(string sceneName)
    {
      
        return SceneManager.LoadSceneAsync(sceneName);

    }

 

}
