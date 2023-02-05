using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRepository : MonoBehaviour
{
    public AudioClipArray[] musicSounds, sfxSounds;

    [Header("Music")]
    public AudioClip backgroundMusic;
    public AudioClip lossMusic;
    public AudioClip winMusic;

    [Header("Sfx")]
    //Player
    public AudioClip walkingSfx;
    public AudioClip sprintSfx;
    public AudioClip dashSfx;
    public AudioClip takeDamageSfx;
    public AudioClip coinPickupSfx;
    //Zombie
    public AudioClip idleSfx;
    public AudioClip screamSfx;
    public AudioClip runningSfx;
    public AudioClip patrolingSfx;
    public AudioClip biteSfx;
    public AudioClip eatingSfx;
    public AudioClip growlSfx;
    public AudioClip moanSfx;
    public AudioClip distanceRoarSfx;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public AudioClip ClipsForMusic(MusicClip clip)
    {
        switch(clip) 
        {
            case MusicClip.Background: return backgroundMusic;
            case MusicClip.Win:        return winMusic;
            case MusicClip.Loss:       return lossMusic;
            default:                   return backgroundMusic;
        }
    }

    public AudioClip ClipsForSfx(SfxClip clip)
    {
        switch(clip) 
        {
            case SfxClip.Walk:        return walkingSfx;
            case SfxClip.Sprint:      return sprintSfx;
            case SfxClip.Dash:        return dashSfx;
            case SfxClip.DamageTaken: return takeDamageSfx;
            case SfxClip.PickUp:      return coinPickupSfx;
            case SfxClip.Idle:        return idleSfx;
            case SfxClip.Scream:      return screamSfx;
            case SfxClip.Running:     return runningSfx;
            case SfxClip.Patroling:   return patrolingSfx;
            case SfxClip.Bite:        return biteSfx;
            case SfxClip.Eating:      return eatingSfx;
            case SfxClip.Growl:       return growlSfx;
            case SfxClip.Moan:        return moanSfx;
            case SfxClip.Roar:        return distanceRoarSfx;
            default:                  return walkingSfx;
        }
    }
}
