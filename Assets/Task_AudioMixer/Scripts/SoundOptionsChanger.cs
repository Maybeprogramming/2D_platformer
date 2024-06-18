using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOptionsChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip _musicAudioClip;
    [SerializeField] private AudioClip _buttonAudioClip1;
    [SerializeField] private AudioClip _buttonAudioClip2;
    [SerializeField] private AudioClip _buttonAudioClip3;

    [SerializeField] private Button _SoundButton1;
    [SerializeField] private Button _SoundButton2;
    [SerializeField] private Button _SoundButton3;
    [SerializeField] private Button _MasterVolumeButton;

    [SerializeField] private Slider _masterVolume;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _buttonsVolume;

    private float masterVolumeLevel;
    private float musicVolumeLevel;
    private float buttonsVolumeLevel;

    public float GetNormalizedSoundValue(float value)
    {
        return Mathf.Log10(value) * 20;
    }

    public void SetMasterVolume()
    {
        masterVolumeLevel = GetNormalizedSoundValue(_masterVolume.value);
        _audioMixer.SetFloat("MasterVolume", masterVolumeLevel);
    }

    public void SetMusicVolume()
    {
        musicVolumeLevel = GetNormalizedSoundValue(_musicVolume.value);
        _audioMixer.SetFloat("MusicVolume", musicVolumeLevel);
    }

    public void SetSfxVolume()
    {
        buttonsVolumeLevel = GetNormalizedSoundValue(_buttonsVolume.value);
        _audioMixer.SetFloat("ButtonsVolume", buttonsVolumeLevel);
    }
}