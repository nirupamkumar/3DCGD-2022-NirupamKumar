using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
                //audioSourceComponentSfx.loop = true;
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

    //Play 3D music at certain gameobject
    public void PlayMusic(MusicClip musicClip, GameObject position, float min, float max)
    {
        var go = position.AddComponent<AudioSource>();
        go.PlayOneShot(audioRepository.ClipsForMusic(musicClip));
        go.spatialBlend = 1;
        go.minDistance = min;
        go.maxDistance = max;
        go.rolloffMode = AudioRolloffMode.Linear;
    }

    //play audio using DOTween
    public void PlayMusic(MusicClip musicClip, AudioSource target, float to, float duration)
    {
        audioSourceMusic.DOFade(to, duration);
    }

    
    public void PlaySfx(SfxClip sfxClip)
    {
        audioSourceSfx.PlayOneShot(audioRepository.ClipsForSfx(sfxClip));
    }


    //loop active for selected audios
    public void PlaySfx(SfxClip sfxClip, bool loopActive)
    {
        audioSourceSfx.loop = loopActive;
        //audioSourceSfx.clip = audioRepository.ClipsForSfx(sfxClip);
        audioSourceSfx.PlayOneShot(audioRepository.ClipsForSfx(sfxClip));
    }

    //loop active for 3D audios
    public void PlaySfx(SfxClip sfxClip, bool loopActive, GameObject gameobjectPos, float min, float max)
    {
        var go = gameobjectPos.AddComponent<AudioSource>();

        go.loop = loopActive;
        go.spatialBlend = 1;
        go.minDistance = min;
        go.maxDistance = max;
        go.rolloffMode = AudioRolloffMode.Linear;

        go.clip = audioRepository.ClipsForSfx(sfxClip);
        go.Play();
    }


    //play audio at Ex: Vector3(0f, 0f, 0f) position by creating new gameobject & audio source
    public void PlaySfx(SfxClip sfxClip, bool audioLoop, Vector3 pos, string objName, float min, float max)
    {
        var emptyComponent = new GameObject();
        emptyComponent.name = objName;
        emptyComponent.transform.position = pos;

        var go = emptyComponent.AddComponent<AudioSource>();
        go.PlayOneShot(audioRepository.ClipsForSfx(sfxClip));
        go.loop = audioLoop;
        go.spatialBlend = 1;
        go.minDistance = min;
        go.maxDistance = max;
        go.rolloffMode = AudioRolloffMode.Linear;
    }


    // 3D audio (Fade In & Out)
    public void PlaySfx(SfxClip sfxClip, GameObject gameobjectPos, float min, float max)
    {
        var go = gameobjectPos.AddComponent<AudioSource>();
        go.PlayOneShot(audioRepository.ClipsForSfx(sfxClip));
        go.spatialBlend = 1;
        go.minDistance = min;
        go.maxDistance = max;
        go.rolloffMode = AudioRolloffMode.Linear;
    }


    //Music is off. When this audio is in full volume - SFX
    public void PlaySfxVolume(SfxClip sfxClip, float volume)
    {
        audioSourceSfx.volume = volume;
        audioSourceMusic.PlayOneShot(audioRepository.ClipsForSfx(sfxClip));


        if (audioSourceSfx.volume == 1)
        {
            audioSourceMusic.mute = true;
        }
        else
        {
            audioSourceMusic.mute = false;
        }

    }

}

public enum MusicClip
{
    Background, Win, Loss
}

public enum SfxClip
{
    Walk, Sprint, Dash, DamageTaken, Idle, Scream, Running, Patroling, Bite, Eating, Growl, Moan, Roar, PickUp
}
