using System.Collections;
using UnityEngine;


public class MotoboyController : MonoBehaviour
{
    private int _currentWaypointIndex = 0;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _resetTimer;

    private void Start()
    {
        StartCoroutine(MoveToWaypoint());
    }

    private IEnumerator MoveToWaypoint()
    {
        while (true)
        {
            Vector3 atualWaypoint = Managers.Instance.MotoboyManager.GetWaypointMotoboy(_currentWaypointIndex);
            float distance = Mathf.Sqrt((transform.position - atualWaypoint).sqrMagnitude);

            transform.position = Vector3.MoveTowards(transform.position, atualWaypoint, _speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(atualWaypoint - transform.position), Time.deltaTime * _rotSpeed);

            if (distance <= .5f)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % Managers.Instance.MotoboyManager.Waypoints.Length;
                if (_currentWaypointIndex == 0) StartCoroutine(Reset());
            }

            yield return null;
        }
    }

    private IEnumerator Reset()
    {
        transform.position = _currentWaypointIndex == 0 ? Managers.Instance.MotoboyManager.GetWaypointMotoboy(0) : transform.position;
        float waitSpeed = _speed;
        _speed = 0;
        yield return new WaitForSeconds(_resetTimer);
        _speed = waitSpeed;
    }
}