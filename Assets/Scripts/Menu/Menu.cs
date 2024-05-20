using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private bool _isViewMenu = false;
    [SerializeField] private GameObject _menu;

    private void Start()
    {
        _menu.SetActive(_isViewMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ViewMenu();
        }
    }

    private void ViewMenu()
    {
        _isViewMenu = !_isViewMenu;
        _menu.SetActive(_isViewMenu);

        if (_isViewMenu == true)
        {
            UnityEngine.Time.timeScale = 0f;
        }
        else
        {
            UnityEngine.Time.timeScale = 1f;
        }
    }
}
