using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TurretFire : TurretController
{
    [SerializeField] private float _radius;

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Managers.Instance.MotoboyManager.Motoboys.Count > 0)
        {
            bool isInsideRange = Mathf.Sqrt((Managers.Instance.MotoboyManager.Motoboys[0].transform.position - transform.position).sqrMagnitude) <= _radius;
            Debug.Log(isInsideRange);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, 0, transform.position.z), _radius);
    }
}