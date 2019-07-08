using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsControler : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defloultVolume = 0.5f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defloultDifficulty = 0f;

    void Start()
    {
        volumeSlider.value = PlayerPrefsControler.GetMasterVolume();
        difficultySlider.value = PlayerPrefsControler.GetDifficulty();
    }


    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsControler.SetMasterDifficulty(difficultySlider.value);
        PlayerPrefsControler.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<SceneLoader>().LoadMainMenu();
    }

    public void SetDefault()
    {
        volumeSlider.value = defloultVolume;
        difficultySlider.value = defloultDifficulty;
    }
}
