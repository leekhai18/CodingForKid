using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager> {

    [SerializeField]
    AudioSource[] audioSources;

    [SerializeField]
    AudioSound[] sounds;



    // Use this for initialization
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
    private void Awake ()
    {
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        DontDestroyOnLoad(gameObject);
	}

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        AudioSound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }


        AudioSource audioSource = GetFreeAudioSource();
        audioSource.clip = s.clip;
        audioSource.loop = s.loop;

        audioSource.Play();
    }

    public void Stop(string name)
    {
        Debug.Log("Stop music"+name);

        AudioSound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }

        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].isPlaying)
            {
                if (audioSources[i].clip.name == s.clip.name)
                {
                    audioSources[i].Pause();
                    audioSources[i].Stop();
                }
            }
        }
    }
    AudioSource GetFreeAudioSource()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                return audioSources[i];
            }
        }

        return audioSources[0];
    }
}
