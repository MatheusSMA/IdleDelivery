using UnityEngine;

public class TurretPlacement : TurretController
{
    [SerializeField] private Material _canPlaceMaterial, _cannotPlaceMaterial;
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
                SetAvaibleMaterial(false);
            else
                SetAvaibleMaterial(true);
    }

    public Material SetAvaibleMaterial(bool state)
    {
        MeshRenderer turretMesh = GetComponent<MeshRenderer>();
        Buildsystem buildsystem = GetComponentInParent<Buildsystem>();
        turretMesh.material = buildsystem.CanPlace == true ? turretMesh.material = _canPlaceMaterial : turretMesh.material = _cannotPlaceMaterial;
        buildsystem.CanPlace = state;
        return turretMesh.material;
    }

    // private void OnDrawGizmos()
    // {
    //     Debug.DrawRay(transform.position, Vector3.down, Gizmos.color = Color.red);
    // }
}