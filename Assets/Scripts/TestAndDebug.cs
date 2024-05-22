using UnityEngine;

public class TestAndDebug : MonoBehaviour
{
    [SerializeField] private float _healthPoint;
    [SerializeField] private float _damage;
    [SerializeField] private Health [] _healthEntities;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (Health health in _healthEntities)
            {
                bool isAdd = health.Add(_healthPoint);
                Debug.Log(isAdd);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (Health healthEntity in _healthEntities)
            {
                bool isRemove = healthEntity.Remove(_damage);
                Debug.Log(isRemove);
            }
        }
    }
}