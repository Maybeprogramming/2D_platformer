using UnityEngine;
using UnityEngine.UI;

public class PlayMusic : PlaySound
{
    public override void Init(Button soundButton, Button masterVolumeButton, AudioClip audioClip)
    {
        Debug.Log("Music Init");
        base.Init(null, masterVolumeButton, null);
        AudioSource.clip = audioClip;
        //base.Init(soundButton, masterVolumeButton, audioClip);
    }

    public override void OnPlaySound()
    {
    }
}