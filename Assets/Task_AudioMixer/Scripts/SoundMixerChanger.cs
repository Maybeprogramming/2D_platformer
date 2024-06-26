using TMPro;
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

    private void Awake()
    {

    }

    private void Start()
    {
        InitAudioSource(_buttonAttack, _buttonMasterVolume, _attackSound);
        InitAudioSource(_buttonHeal, _buttonMasterVolume, _healSound);
        InitAudioSource(_buttonPay, _buttonMasterVolume, _paySound);
        InitAudioSource(_buttonMasterVolume, _buttonMasterVolume, _backgoundMusic);
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
    private void InitAudioSource(Button currentButton, Button masterVolumeButton, AudioClip audioClip)
    {
        currentButton.TryGetComponent(out PlaySound playSound);
        playSound?.Init(currentButton, masterVolumeButton, audioClip);
    }

    private float GetNormalizedSoundVolume(float value)
    {
        return Mathf.Log10(value) * 20;
    }

    //private void OnSoundVolumeMute()
    //{
    //    TextMeshProUGUI text = _buttonMasterVolume.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    //    text.text = _audioSourceMusic.mute == false ? "Turn sound Off" : "Turn sound On";
    //}
}