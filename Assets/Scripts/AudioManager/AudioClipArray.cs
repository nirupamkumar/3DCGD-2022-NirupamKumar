using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioClipArray
{
    public string _clipName;
    public AudioClip _audioClip;

    [Range(0f, 1f)] public float _volume;
    [Range(0.1f, 3f)] public float _pitch;

    public bool _loop;

    public AudioSource _audioSource;
}
