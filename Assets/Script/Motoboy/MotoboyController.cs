using System;
using System.Collections.Generic;
using UnityEngine;


public class MotoboyController : MonoBehaviour
{
    private int _currentWaypointIndex = 0;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotSpeed;

    private void Start()
    {
        StartCoroutine(MoveToWaypoint());
    }

    private System.Collections.IEnumerator MoveToWaypoint()
    {
        while (true)
        {
            float distance = Mathf.Sqrt((transform.position - Managers.Instance.MotoboyManager.GetWaypointMotoboy(_currentWaypointIndex)).sqrMagnitude);

            transform.position = Vector3.MoveTowards(transform.position, Managers.Instance.MotoboyManager.GetWaypointMotoboy(_currentWaypointIndex), _speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Managers.Instance.MotoboyManager.GetWaypointMotoboy(_currentWaypointIndex) - transform.position), Time.deltaTime * _rotSpeed);

            if (distance <= .5f)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % Managers.Instance.MotoboyManager.Waypoints.Length;
            }

            yield return null;
        }
    }
}