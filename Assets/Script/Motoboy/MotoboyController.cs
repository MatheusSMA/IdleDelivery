using UnityEngine;

public class MotoboyController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField]
    private Transform[] waypoints;

    private void Update()
    {

        for (int i = 0; i < waypoints.count; i++)
        {
            // Vector3 run = new Vector3(waypoints[i].x, 1, waypoints[i].z);
        }
        //SetOrientation
        //sqrt |a-b| distancia * distancia
    }
}