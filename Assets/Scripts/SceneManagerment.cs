using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerment : Singleton<SceneManagerment> {
    private static bool created = false;
    public static float starOfCounting=3;
    // Use this for initialization
    void Start () {
        if (!created)
        {
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
        Debug.Log("On loading scene");
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
        if (parameters == null) return "";
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
