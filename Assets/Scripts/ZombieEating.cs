using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEating : MonoBehaviour
{
    
    void Start()
    {
        //AudioManager.SingletonManager.PlayMusic(MusicClip.Background, this.gameObject, 1, 15);

        //AudioManager.SingletonManager.PlayMusic(MusicClip.Background, new Vector3(96, -8, -44), "ZOmbieEating", 1, 10);

        //AudioManager.SingletonManager.PlayMusic(MusicClip.Background, new Vector3(0, 0, 0), "Zombi", 1, 30);

        //AudioManager.SingletonManager.PlaySfx(SfxClip.Scream,true, this.gameObject, 1, 15);

        AudioManager.SingletonManager.PlaySfx(SfxClip.Moan, true, new Vector3(94, -5, -41), "ZombieEating", 1, 30);
    }

}
