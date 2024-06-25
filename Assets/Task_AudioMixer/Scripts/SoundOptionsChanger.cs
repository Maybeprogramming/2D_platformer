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

    private float _masterVolumeLevel;
    private float _musicVolumeLevel;
    private float _buttonsVolumeLevel;
    private bool _isSoundVolumeMuted;

    public event Action<bool> SoundMuteChanged;


    private void Start()
    {
        _audioSourceMusic.clip = _musicAudioClip;
        _audioSourceButton1.clip = _buttonAudioClip1;
        _audioSourceButton2.clip = _buttonAudioClip2;
        _audioSourceButton3.clip = _buttonAudioClip3;

        _audioSourceMusic.Play();
    }

    private void OnEnable()
    {
        _soundButton1.onClick.AddListener(OnPlayOneShootSound1);
        _soundButton2.onClick.AddListener(OnPlayOneShootSound2);
        _soundButton3.onClick.AddListener(OnPlayOneShootSound3);
        _masterVolumeButton.onClick.AddListener(OnSoundVolumeMute);
    }

    private void OnDisable()
    {
        _soundButton1.onClick.RemoveListener(OnPlayOneShootSound1);
        _soundButton2.onClick.RemoveListener(OnPlayOneShootSound2);
        _soundButton3.onClick.RemoveListener(OnPlayOneShootSound3);
        _masterVolumeButton.onClick.RemoveListener(OnSoundVolumeMute);
    }

    public void SetMasterVolume()
    {
        _masterVolumeLevel = GetNormalizedSoundVolume(_masterVolumeSlider.value);
        _audioMixer.SetFloat(MasterVolumeTag, _masterVolumeLevel);
    }

    public void SetMusicVolume()
    {
        _musicVolumeLevel = GetNormalizedSoundVolume(_musicVolumeSlider.value);
        _audioMixer.SetFloat(MusicVolumeTag, _musicVolumeLevel);
    }

    public void SetButtonsSoundVolume()
    {
        _buttonsVolumeLevel = GetNormalizedSoundVolume(_buttonsVolumeSlider.value);
        _audioMixer.SetFloat(ButtonsVolumeTag, _buttonsVolumeLevel);
    }

    private float GetNormalizedSoundVolume(float value)
    {
        return Mathf.Log10(value) * 20;
    }

    private void OnPlayOneShootSound1()
    {
        Debug.Log("Play One Shoot 1");
        _audioSourceButton1.PlayOneShot(_buttonAudioClip1);
    }    
    
    private void OnPlayOneShootSound2()
    {
        Debug.Log("Play One Shoot 2");
        _audioSourceButton2.PlayOneShot(_buttonAudioClip2);
    }    
    
    private void OnPlayOneShootSound3()
    {
        Debug.Log("Play One Shoot 3");
        _audioSourceButton3.PlayOneShot(_buttonAudioClip3);
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