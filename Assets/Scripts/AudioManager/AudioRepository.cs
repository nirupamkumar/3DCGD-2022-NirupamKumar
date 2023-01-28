using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRepository : MonoBehaviour
{
    //public AudioClipArray[] musicSounds, sfxSounds;

    [Header("-Music-")]
    public AudioClip backgroundMusic;
    public AudioClip lossMusic;
    public AudioClip winMusic;

    [Header("-Sfx-")]
    public AudioClip walkingSfx;
    public AudioClip sprintSfx;
    public AudioClip dashSfx;
    public AudioClip takeDamageSfx;

    public AudioClip idleSfx;
    public AudioClip screamSfx;
    public AudioClip runningSfx;
    public AudioClip patrolingSfx;
    public AudioClip biteSfx;
    public AudioClip eatingSfx;
    public AudioClip growlSfx;
    public AudioClip moanSfx;
    public AudioClip distanceRoarSfx;

    public AudioClip coinPickupSfx;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public AudioClip ClipsForMusic(MusicClip clip)
    {
        switch(clip) 
        {
            case MusicClip.Background:
                return backgroundMusic;
            case MusicClip.Win:
                return winMusic;
            case MusicClip.Loss:
                return lossMusic;
            default:
                return backgroundMusic;
        }
    }

    public AudioClip ClipsForSfx(SfxClip clip)
    {
        switch(clip) 
        {
            case SfxClip.Walk:
                return walkingSfx;
            case SfxClip.Sprint:
                return sprintSfx;
            case SfxClip.Dash:
                return dashSfx;
            case SfxClip.DamageTaken:
                return takeDamageSfx;
            case SfxClip.Bite:
                return biteSfx;
            case SfxClip.Scream:
                return coinPickupSfx;
            case SfxClip.PickUp:
                return coinPickupSfx;
            default:
                return walkingSfx;

        }
    }
}
