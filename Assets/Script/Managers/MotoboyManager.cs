using System.Collections.Generic;
using UnityEngine;

public class MotoboyManager : MonoBehaviour
{
    [SerializeField] private int _qtdMotoboy;
    [SerializeField] private GameObject _motoboyPrefab;
    [SerializeField] private List<MotoboyController> _motoboys = new List<MotoboyController>();
    [SerializeField] private Transform[] _waypoints;

    public Transform[] Waypoints { get => _waypoints; set => _waypoints = value; }

    public void AddMotoboy()
    {
        MotoboyController newMotoboy = Instantiate(_motoboyPrefab, Waypoints[0].transform.position, transform.rotation).GetComponent<MotoboyController>();
        _motoboys.Add(newMotoboy);
    }

    public Vector3 GetWaypointMotoboy(int index)
    {
        return Waypoints[index].position;
    }
}