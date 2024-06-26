using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerChanger : MonoBehaviour
{
    private const string MasterVolumeTag = "MasterVolume";
    private const string ButtonsVolumeTag = "ButtonsVolume";
    private const string MusicVolumeTag = "MusicVolume";

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _buttonsVolumeSlider;
    [SerializeField] private AudioClip _backgoundMusic;
    [SerializeField] private AudioClip _attackSound;
    [SerializeField] private AudioClip _healSound;
    [SerializeField] private AudioClip _paySound;
    [SerializeField] private Button _buttonMasterVolume;
    [SerializeField] private Button _buttonAttack;
    [SerializeField] private Button _buttonHeal;
    [SerializeField] private Button _buttonPay;

    private float _masterVolumeLevel;
    private float _musicVolumeLevel;
    private float _buttonsVolumeLevel;

    private void Start()
    {
        InitAudioSource(_buttonAttack, _buttonMasterVolume, _attackSound);
        InitAudioSource(_buttonHeal, _buttonMasterVolume, _healSound);
        InitAudioSource(_buttonPay, _buttonMasterVolume, _paySound);
        InitAudioSource(_buttonMasterVolume, _buttonMasterVolume, _backgoundMusic);
    }

    public void SetMasterVolume()
    {
        SetVolumeByTag(MasterVolumeTag, _masterVolumeLevel, _masterVolumeSlider);
    }

    public void SetMusicVolume()
    {
        SetVolumeByTag(MusicVolumeTag, _musicVolumeLevel, _musicVolumeSlider);
    }

    public void SetButtonsSoundVolume()
    {
        SetVolumeByTag(ButtonsVolumeTag, _buttonsVolumeLevel, _buttonsVolumeSlider);
    }

    private void SetVolumeByTag(string volumeNameTag, float volumeLevel, Slider slider)
    {
        volumeLevel = GetNormalizedSoundVolume(slider.value);
        _audioMixer.SetFloat(volumeNameTag, volumeLevel);
    }

    private void InitAudioSource(Button currentButton, Button masterVolumeButton, AudioClip audioClip)
    {
        currentButton.TryGetComponent(out PlaySound playSound);
        playSound?.Init(currentButton, masterVolumeButton, audioClip);
    }

    private float GetNormalizedSoundVolume(float value)
    {
        return Mathf.Log10(value) * 20;
    }
}