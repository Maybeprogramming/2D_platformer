using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOptionsChanger : MonoBehaviour
{
    private const string MasterVolumeTag = "MasterVolume";
    private const string ButtonsVolumeTag = "ButtonsVolume";
    private const string MusicVolumeTag = "MusicVolume";

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceButton1;
    [SerializeField] private AudioSource _audioSourceButton2;
    [SerializeField] private AudioSource _audioSourceButton3;
    [SerializeField] private AudioClip _musicAudioClip;
    [SerializeField] private AudioClip _buttonAudioClip1;
    [SerializeField] private AudioClip _buttonAudioClip2;
    [SerializeField] private AudioClip _buttonAudioClip3;
    [SerializeField] private Button _soundButton1;
    [SerializeField] private Button _soundButton2;
    [SerializeField] private Button _soundButton3;
    [SerializeField] private Button _masterVolumeButton;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _buttonsVolumeSlider;

    private float masterVolumeLevel;
    private float musicVolumeLevel;
    private float buttonsVolumeLevel;

    private void Start()
    {
        //_audioSourceMusic.clip = _musicAudioClip;
        //_audioSourceButton1.clip = _buttonAudioClip1;
        //_audioSourceButton2.clip = _buttonAudioClip2;
        //_audioSourceButton3.clip = _buttonAudioClip3;

        _soundButton1.onClick.AddListener(OnPlayOneShootSound);
        _soundButton2.onClick.AddListener(OnPlayOneShootSound);
        _soundButton3.onClick.AddListener(OnPlayOneShootSound);
        _masterVolumeButton.onClick.AddListener(OnSetMasterSound);
    }

    public void SetMasterVolume()
    {
        masterVolumeLevel = GetNormalizedSoundValue(_masterVolumeSlider.value);
        _audioMixer.SetFloat(MasterVolumeTag, masterVolumeLevel);
    }


    public void SetMusicVolume()
    {
        musicVolumeLevel = GetNormalizedSoundValue(_musicVolumeSlider.value);
        _audioMixer.SetFloat(MusicVolumeTag, musicVolumeLevel);
    }

    public void SetButtonsSoundVolume()
    {
        buttonsVolumeLevel = GetNormalizedSoundValue(_buttonsVolumeSlider.value);
        _audioMixer.SetFloat(ButtonsVolumeTag, buttonsVolumeLevel);
    }

    private float GetNormalizedSoundValue(float value)
    {
        return Mathf.Log10(value) * 20;
    }

    private void OnPlayOneShootSound()
    {
        Debug.Log("Play One Shoot");
    }

    private void OnSetMasterSound()
    {
        _audioSourceButton1.mute = !_audioSourceButton1.mute;
        _audioSourceButton2.mute = !_audioSourceButton2.mute;
        _audioSourceButton3.mute = !_audioSourceButton3.mute;
        _audioSourceMusic.mute = !_audioSourceMusic.mute;

        TMP_Text text = _masterVolumeButton.GetComponent<TMP_Text>();
        text.text = _audioSourceButton1.mute == false ? "Turn sound Off" : "Turn sound On";
    }
}