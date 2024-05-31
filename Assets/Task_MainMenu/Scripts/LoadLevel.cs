using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private int _levelNumber = 1;

    public void OnLoadLevel()
    {
        SceneManager.LoadScene(_levelNumber);
    }
}