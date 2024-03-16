using UnityEditor;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private float _speed;

    private int _targetIndex = 0;
    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = _targetPoints[0].position;
    }

    private void Update()
    {
        if (transform.position == _targetPosition)
        {
            _targetIndex++;

            if (_targetPoints.Length == _targetIndex)
            {
                _targetIndex = 0;
            }

            _targetPosition = _targetPoints[_targetIndex].position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
}
