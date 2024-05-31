using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _animationTrigger;

    private void Update()
    {
        _button.animationTriggers.normalTrigger = "";
    }
}