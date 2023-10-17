using UnityEngine;
using UnityEngine.UI;
using System;

public class Settings : MonoBehaviour
{
    public AudioSource[] soundEffectAudioSources;
    public AudioSource musicAudioSources;
    
    public GameObject settingsPanel;

    public Image soundImg;
    public Image musicImg;

    public Sprite on;
    public Sprite off;

    private bool soundMuted;
    private bool musicMuted;

    void Start()
    {
        int soundMutedInt = PlayerPrefs.GetInt("SoundSwitch");
        soundMuted = Convert.ToBoolean(soundMutedInt);

        int musicMutedInt = PlayerPrefs.GetInt("MusicSwitch");
        musicMuted = Convert.ToBoolean(musicMutedInt);

        foreach (var audioSource in soundEffectAudioSources)
        {
            audioSource.mute = soundMuted;
        }

        musicAudioSources.mute = musicMuted;

        if (!soundMuted)
            soundImg.sprite = on;
        else 
            soundImg.sprite = off;

        if (!musicMuted)
            musicImg.sprite = on;
        else 
            musicImg.sprite = off;
    }

    public void SettingsButton()
    {
        MusicManager.buttonClickS.Play();
        settingsPanel.SetActive(true);
    }

    public void SaveButton()
    {
        MusicManager.buttonClickS.Play();
        settingsPanel.SetActive(false);
    }

    public void SoundButton(Image buttonSwitch)
    {
        MusicManager.buttonClickS.Play();
        soundMuted = !soundMuted;

        if(!soundMuted)
            buttonSwitch.sprite = on;
        else 
            buttonSwitch.sprite = off;

        foreach (var audioSource in soundEffectAudioSources)
        {
            audioSource.mute = soundMuted;
        }

        int switchSound;
        switchSound = Convert.ToInt32(soundMuted);

        PlayerPrefs.SetInt("SoundSwitch", switchSound);
    }

    public void MusicButton(Image buttonSwitch)
    {
        musicMuted = !musicMuted;

        musicAudioSources.mute = musicMuted;

        if (!musicMuted)
            buttonSwitch.sprite = on;
        else buttonSwitch.sprite = off;

        int switchMusic;
        switchMusic = Convert.ToInt32(musicMuted);

        PlayerPrefs.SetInt("MusicSwitch", switchMusic);

        MusicManager.buttonClickS.Play();
    }
}
