using UnityEngine;

public class FlipDetector : MonoBehaviour
{
    [SerializeField] private int _directionRawX;

    public void Flip(Vector2 direction)
    {
        _directionRawX = (int)direction.x;

        if (_directionRawX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (_directionRawX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
