using UnityEngine;
using UnityEngine.UI;

public class MenuViev : MonoBehaviour
{
    private const float PauseTime = 0f;
    private const float ResumeTime = 1f;

    [SerializeField] private bool _isViewMenuAtStart = false;
    [SerializeField] private GameObject _menu;
    [SerializeField] private PlayerInputModule _playerInputModule;
    [SerializeField] private bool _isEnableInput = true;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _menu.SetActive(_isViewMenuAtStart);
    }

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(ViewMenu);
        _continueButton.onClick.AddListener(EnablePlayerInput);
        _exitButton.onClick.AddListener(ApplicationExit);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(ViewMenu);
        _continueButton.onClick.RemoveListener(EnablePlayerInput);
        _exitButton.onClick.RemoveListener(ApplicationExit);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ViewMenu();
            EnablePlayerInput();
        }
    }

    private void ViewMenu()
    {
        _isViewMenuAtStart = !_isViewMenuAtStart;
        _menu.SetActive(_isViewMenuAtStart);

        Time.timeScale = _isViewMenuAtStart == true ? PauseTime : ResumeTime;
    }

    private void EnablePlayerInput()
    {
        _isEnableInput = !_isEnableInput;
        _playerInputModule.enabled = _isEnableInput;
    }

    private void ApplicationExit()
    {
        Application.Quit();
    }
}