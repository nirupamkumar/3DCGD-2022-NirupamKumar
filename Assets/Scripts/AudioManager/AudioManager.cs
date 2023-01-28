using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    private AudioSource audioSourceMusic;
    private AudioSource audioSourceSfx;

    private AudioRepository audioRepository;

    private static AudioManager _singletonManager;

    public static AudioManager SingletonManager
    {
        get
        {
            if(_singletonManager != null)
            {
                return _singletonManager;
            }
            else
            {
                //isMusic
                var audioManagerGOMusic = new GameObject();
                audioManagerGOMusic.name = "Music AudioManager";
                var audioSourceComponentMusic = audioManagerGOMusic.AddComponent<AudioSource>();
                audioSourceComponentMusic.loop = true;
                GameObject.DontDestroyOnLoad(audioManagerGOMusic);

                _singletonManager = new AudioManager();
                _singletonManager.audioSourceMusic = audioSourceComponentMusic;

                //isSFX
                var audioManagerGOSfx = new GameObject();
                audioManagerGOSfx.name = "Sfx AudioManager";
                var audioSourceComponentSfx = audioManagerGOSfx.AddComponent<AudioSource>();
                GameObject.DontDestroyOnLoad(audioManagerGOSfx);
                _singletonManager.audioSourceSfx = audioSourceComponentSfx;

                _singletonManager.audioRepository = GameObject.FindObjectOfType<AudioRepository>();

                
                return _singletonManager;
            }
        }
    }

    public void PlayMusic(MusicClip musicClip)
    {
        audioSourceMusic.PlayOneShot(audioRepository.ClipsForMusic(musicClip));
    }

    public void PlaySfx(SfxClip sfxClip)
    {
        audioSourceSfx.PlayOneShot(audioRepository.ClipsForSfx(sfxClip));
    }
}

public enum MusicClip
{
    Background, Win, Loss
}

public enum SfxClip
{
    Walk, Sprint, Dash, Bite, Scream, DamageTaken, PickUp
}
