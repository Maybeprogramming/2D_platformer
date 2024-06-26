using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMuteTextChanger : MonoBehaviour
{
    const string MuteText = "Turn sound On";
    const string UnMuteText = "Turn sound Off";

    [SerializeField] private TextMeshProUGUI _muteText;
    [SerializeField] private Button muteButton;

    private bool isMute;

    private void Start()
    {
        _muteText = GetComponentInChildren<TextMeshProUGUI>();
        isMute = false;
    }

    private void OnEnable()
    {
        muteButton.onClick.AddListener(OnMuteTextChanged);
    }

    private void OnDisable()
    {
        muteButton.onClick.RemoveListener(OnMuteTextChanged);
    }

    private void OnMuteTextChanged()
    {
        isMute = !isMute;
        _muteText.text = isMute == false ? UnMuteText : MuteText;
    }
}
