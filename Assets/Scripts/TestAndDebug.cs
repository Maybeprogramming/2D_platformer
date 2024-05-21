using UnityEngine;

public class TestAndDebug : MonoBehaviour
{
    [SerializeField] private float _healthToAdd;
    [SerializeField] private float _healthToRemove;
    [SerializeField] private Health [] _health;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (Health health in _health)
            {
                bool isAdd = health.Add(_healthToAdd);
                Debug.Log(isAdd);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (Health health in _health)
            {
                bool isRemove = health.Remove(_healthToRemove);
                Debug.Log(isRemove);
            }
        }
    }
}