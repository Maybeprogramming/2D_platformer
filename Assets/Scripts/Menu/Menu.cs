using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private bool _isViewMenu = false;
    [SerializeField] private GameObject _menu;
    [SerializeField] private PlayerInputModule _playerInputModule;
    [SerializeField] private bool _isEnableInput = true;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _menu.SetActive(_isViewMenu);
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
        _isViewMenu = !_isViewMenu;
        _menu.SetActive(_isViewMenu);

        Time.timeScale = _isViewMenu == true ? 0f : 1f;
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