using UnityEngine.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public Audio_Collection[] _audios;
    public static Audio_Manager instance;
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Audio_Collection a in _audios)
        {
            a._source = gameObject.AddComponent<AudioSource>();
            a._source.clip = a._clip;
            a._source.volume = a._volume;
            a._source.pitch = a._pitch;
            a._source.loop = a._doLoop;
            a._source.mute = a._mute;
        }
    }

    private void Start()
    {
        Play_Audio("background_music");
    }

    public void Play_Audio(string _name)
    {
        Audio_Collection a = Array.Find(_audios, _audio => _audio._clipName == _name);
        if(a==null)
        {
            Debug.LogWarning("Audio clip:" + _name + " not found.");
            return;
        }
        a._source.Play();
    }
}

