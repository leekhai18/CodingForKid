using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager> {
    private static bool createdAudioM = false;

    [SerializeField]
    AudioSource[] audioSources;

    [SerializeField]
    AudioSound[] sounds;


    // Use this for initialization
    private void Awake ()
    {
        if (!createdAudioM)
        {
            DontDestroyOnLoad(this.gameObject);
            createdAudioM = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}

    private void Start()
    {
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
        AudioSound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }

        if (s != null)
        {
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
    }

    public bool IsPlaying(string name)
    {
        AudioSound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return false;
        }

        if (s != null)
        {
            for (int i = 0; i < audioSources.Length; i++)
            {
                if (audioSources[i].isPlaying)
                {
                    if (audioSources[i].clip.name == s.clip.name)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
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

    public AudioSource[] GetListAudioSources()
    {
        return audioSources;
    }
}
