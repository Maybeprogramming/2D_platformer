using UnityEngine;

public class TestAndDebug : MonoBehaviour
{
    [SerializeField] private float _healthToAdd;
    [SerializeField] private float _healthToRemove;
    [SerializeField] private Health _health;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bool isAdd = _health.Add(_healthToAdd);
            Debug.Log(isAdd);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bool isRemove = _health.Remove(_healthToRemove);
            Debug.Log(isRemove);
        }
    }
}