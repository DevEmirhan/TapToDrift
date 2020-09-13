using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip winSfx, loseSfx;
    public AudioSource audSource;
    public void PlayLoseSound()
    {
        audSource.PlayOneShot(loseSfx);
    }
    public void PlayWinSound()
    {
        audSource.PlayOneShot(winSfx);
    }
}
