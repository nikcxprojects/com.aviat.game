using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    
    [SerializeField] private Text musicText;
    [SerializeField] private Text soundText;
    
    private int volumeSounds;
    private int volumeMusic;
    
    void Start()
    {
        volumeSounds = PlayerPrefs.GetInt("Sounds", 1);
        volumeMusic = PlayerPrefs.GetInt("Music", 1);
        UpdateUI();
    }

    public void ChangeSoundsVolume()
    {
        volumeSounds = volumeSounds == 0 ? 1 : 0;
        PlayerPrefs.SetInt("Sounds", volumeSounds);
        UpdateUI();
    }

    public void ChangeMusicVolume()
    {
        volumeMusic = volumeMusic == 0 ? 1 : 0;
        PlayerPrefs.SetInt("Music", volumeMusic);
        UpdateUI();
    }

    private void UpdateUI()
    {
        musicText.text = "MUSIC:" + (volumeMusic == 0 ? "OFF" : "ON");
        soundText.text = "SOUNDS:" + (volumeSounds == 0 ? "OFF" : "ON");
    }
    
}
