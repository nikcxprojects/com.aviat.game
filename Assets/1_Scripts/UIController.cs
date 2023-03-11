using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Serializable]
    public struct IObject
    {
        public GameObject gameObject;
        public string name;
    }

    [SerializeField] private AudioClip _clip;

    [SerializeField] private IObject[] _objects;

    [SerializeField] private string _defaultCanvas;

    private void Awake()
    {
        ShowCanvas(_defaultCanvas);
        Application.targetFrameRate = 90;
    }
    
    public void ShowCanvas(string name)
    {
        AudioManager.getInstance().PlayAudio(_clip);
        foreach (var obj in _objects)
        {
            if (obj.name.Equals(name)) obj.gameObject.SetActive(true);
            else obj.gameObject.SetActive(false);
        }
    }

    public void HideCanvases()
    {
        AudioManager.getInstance().PlayAudio(_clip);
        foreach (var obj in _objects)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
