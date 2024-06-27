using UnityEngine;
using UnityEngine.UI;

public class MusicSource : SoundSource
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