using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource bgm;
    public AudioSource sfx;

    public AudioClip bgmClip;
    public AudioClip sfxClip1;
    public AudioClip sfxClip2;
    public AudioClip sfxClip3;

    private void Awake()
    {
        Instance = this;
    }   

    private void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
        if (!bgm.isPlaying) 
        { 
            bgm.clip = bgmClip;
            bgm.loop = true;
            bgm.Play(); 
        }
        else bgm.Stop();
    }


    public void PlaySFX(int clipIndex)
    {
        AudioClip clip;

        switch (clipIndex)
        {
            case 1:
                clip = sfxClip1;
                break;

            case 2:
                clip = sfxClip2;
                break;

            default:
                clip = sfxClip3;
                break;
        }
        sfx.PlayOneShot(clip);
    }

    public void SetBGMVolume(float volume)
    {
        if (bgm != null)
        {
            bgm.volume = volume;
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (sfx != null)
        {
            sfx.volume = volume;
        }
    }


}
