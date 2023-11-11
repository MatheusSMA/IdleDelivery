using System;
using System.Collections.Generic;
using UnityEngine;


public class MotoboyController : MonoBehaviour
{
    private int _currentWaypointIndex = 0;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private Transform[] waypoints;

    private void Start()
    {
        StartCoroutine(MoveToWaypoint());
    }

    private System.Collections.IEnumerator MoveToWaypoint()
    {
        while (true)
        {
            float distance = Mathf.Sqrt((transform.position - waypoints[_currentWaypointIndex].position).sqrMagnitude);

            transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypointIndex].position, _speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(waypoints[_currentWaypointIndex].position - transform.position), Time.deltaTime * _rotSpeed);

            if (distance <= .5f)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
            }

            yield return null;
        }
    }
}