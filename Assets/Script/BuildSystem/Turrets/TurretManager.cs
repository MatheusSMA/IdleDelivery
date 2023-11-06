using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private bool _placed = false;

    public bool Placed { get => _placed; set => _placed = value; }

    private void Update()
    {
        if (!Placed) CheckPlaceAvaible();
    }

    public void CheckPlaceAvaible()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 10))

            if (hit.transform.CompareTag("CannotPlace"))
                Buildsystem.Instance.SetAvaibleMaterial(false);
            else
                Buildsystem.Instance.SetAvaibleMaterial(true);

    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down, Gizmos.color = Color.red);
    }


}