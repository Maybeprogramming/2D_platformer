using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _masterVolumeButton;

    public AudioSource AudioSource => _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
    }

    private void OnDisable()
    {
        _soundButton?.onClick.RemoveListener(OnPlaySound);
        _masterVolumeButton?.onClick.RemoveListener(OnSoundMuted);
    }

    public virtual void Init(Button soundButton, Button masterVolumeButton, AudioClip audioClip)
    {
        _soundButton = soundButton;
        _masterVolumeButton = masterVolumeButton;
        _audioClip = audioClip;
        _soundButton?.onClick.AddListener(OnPlaySound);
        _masterVolumeButton?.onClick.AddListener(OnSoundMuted);
    }

    public virtual void OnPlaySound()
    {
        _audioSource.PlayOneShot(_audioClip);
        Debug.Log($"Sound played on <{gameObject.name}> button");
    }

    private void OnSoundMuted()
    {
        _audioSource.mute = !_audioSource.mute;
    }
}