using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private bool _isViewMenu = false;
    [SerializeField] private GameObject _menu;
    [SerializeField] private PlayerInputModule _playerInputModule;
    [SerializeField] private bool _isEnableInput = true;

    private void Start()
    {
        _menu.SetActive(_isViewMenu);
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
}