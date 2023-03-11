using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{

    private float time = 0;

    public AudioType type;

    private void OnEnable()
    {
        switch (type)
        {
            case AudioType.Music:
                GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("Music", 1);
                break;
            case AudioType.Sounds:
                GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("Sounds", 1);
                break;
        }

        time = GetComponent<AudioSource>().clip.length;
    }

    public void Init(float time)
    {
        StopAllCoroutines();
        this.time = time;
        Destroy(gameObject, this.time);
    }

    public void Destroy()
    {
        Destroy(gameObject, this.time);
    }

    public enum AudioType
    {
        Sounds,
        Music
    }
}