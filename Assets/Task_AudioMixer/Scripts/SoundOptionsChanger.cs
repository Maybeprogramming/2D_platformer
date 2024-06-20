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
    private bool _isSoundVolumeMuted;

    public event Action<bool> SoundMuteChanged;


    private void Start()
    {
        _audioSourceMusic.clip = _musicAudioClip;
        //_audioSourceButton1.clip = _buttonAudioClip1;
        //_audioSourceButton2.clip = _buttonAudioClip2;
        //_audioSourceButton3.clip = _buttonAudioClip3;

        _audioSourceMusic.Play();
    }

    private void OnEnable()
    {
        _soundButton1.onClick.AddListener(OnPlayOneShootSound);
        _soundButton2.onClick.AddListener(OnPlayOneShootSound);
        _soundButton3.onClick.AddListener(OnPlayOneShootSound);
        _masterVolumeButton.onClick.AddListener(OnSoundVolumeMute);
    }

    private void OnDisable()
    {
        _soundButton1.onClick.RemoveListener(OnPlayOneShootSound);
        _soundButton2.onClick.RemoveListener(OnPlayOneShootSound);
        _soundButton3.onClick.RemoveListener(OnPlayOneShootSound);
        _masterVolumeButton.onClick.RemoveListener(OnSoundVolumeMute);
    }

    public void SetMasterVolume()
    {
        masterVolumeLevel = GetNormalizedSoundVolume(_masterVolumeSlider.value);
        _audioMixer.SetFloat(MasterVolumeTag, masterVolumeLevel);
    }

    public void SetMusicVolume()
    {
        musicVolumeLevel = GetNormalizedSoundVolume(_musicVolumeSlider.value);
        _audioMixer.SetFloat(MusicVolumeTag, musicVolumeLevel);
    }

    public void SetButtonsSoundVolume()
    {
        buttonsVolumeLevel = GetNormalizedSoundVolume(_buttonsVolumeSlider.value);
        _audioMixer.SetFloat(ButtonsVolumeTag, buttonsVolumeLevel);
    }

    private float GetNormalizedSoundVolume(float value)
    {
        return Mathf.Log10(value) * 20;
    }

    private void OnPlayOneShootSound()
    {
        Debug.Log("Play One Shoot");
    }

    private void OnSoundVolumeMute()
    {
        _audioSourceButton1.mute = !_audioSourceButton1.mute;
        _audioSourceButton2.mute = !_audioSourceButton2.mute;
        _audioSourceButton3.mute = !_audioSourceButton3.mute;
        _audioSourceMusic.mute = !_audioSourceMusic.mute;

        _isSoundVolumeMuted = _audioSourceMusic.mute;
        SoundMuteChanged?.Invoke(_isSoundVolumeMuted);

        TextMeshProUGUI text = _masterVolumeButton.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        text.text = _audioSourceButton1.mute == false ? "Turn sound Off" : "Turn sound On";
    }
}