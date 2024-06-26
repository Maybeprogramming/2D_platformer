using UnityEngine;
using UnityEngine.UI;

public class PlayMusic : PlaySound
{
    public override void Init(Button soundButton, Button masterVolumeButton, AudioClip audioClip)
    {
        AudioSource.clip = audioClip;
        AudioSource.Play();
        soundButton = null;
        audioClip = null;
        base.Init(soundButton, masterVolumeButton, audioClip);
    }
}