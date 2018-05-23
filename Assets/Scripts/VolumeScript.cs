using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour {
    [SerializeField]
    GameObject sliderVolumn;

    private void Start()
    {
        sliderVolumn.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volumn", 1);
    }

    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);

        AudioSource[] audioSources = AudioManager.Instance.GetListAudioSources();

        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].volume = volume;
            PlayerPrefs.SetFloat("Volumn", volume);
        }
    }
}
