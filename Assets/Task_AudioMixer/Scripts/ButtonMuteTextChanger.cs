using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMuteTextChanger : MonoBehaviour
{
    const string MuteText = "Turn sound On";
    const string UnMuteText = "Turn sound Off";

    [SerializeField] private TextMeshProUGUI _muteText;
    [SerializeField] private Button _muteButton;

    private bool _isMute;

    private void Start()
    {
        _muteText = GetComponentInChildren<TextMeshProUGUI>();
        _isMute = false;
    }

    private void OnEnable()
    {
        _muteButton.onClick.AddListener(OnMuteTextChanged);
    }

    private void OnDisable()
    {
        _muteButton.onClick.RemoveListener(OnMuteTextChanged);
    }

    private void OnMuteTextChanged()
    {
        _isMute = !_isMute;
        _muteText.text = _isMute == false ? UnMuteText : MuteText;
    }
}