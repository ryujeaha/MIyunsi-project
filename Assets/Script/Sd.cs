using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Audio;
using UnityEngine.UI;

public class Sd : MonoBehaviour
{
    public AudioMixer mastermixer;
    public Slider audioslider;

    public void AudioControl()
    {
        float sound = audioslider.value;

        if (sound == 40f) mastermixer.SetFloat("BGM", -80);
        else mastermixer.SetFloat("BGM", sound);
    }

    public void toggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
    
}
