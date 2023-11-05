using System.Collections.Generic;
using UnityEngine;

public class Buildsystem : MonoBehaviour
{
    //Singleton
    public static Buildsystem Instance;

    //Vars
    private GameObject _currentTurret;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Grid _grid;
    [SerializeField] private Material _canPlaceMaterial, _cannotPlaceMaterial;
    private bool _canPlace;
    public bool CanPlace { get => _canPlace; set => _canPlace = value; }

    private void Awake()
    {
        Instance = this;
    }

    public void BeginSelect(GameObject prefab)
    {
        GameObject newTurret = Instantiate(prefab, transform);
        _currentTurret = newTurret;
    }

    public void DragSelect()
    {
        Vector3 mousePos = _inputManager.GetMousePos();
        Vector3Int gridPosition = _grid.WorldToCell(mousePos);
        _currentTurret.transform.position = new Vector3(_grid.CellToWorld(gridPosition).x, .01f, _grid.CellToWorld(gridPosition).z);
    }

    public void SetMaterial(bool state)
    {
        CanPlace = state;
        MeshRenderer turretMesh = _currentTurret.GetComponent<MeshRenderer>();
        turretMesh.material = CanPlace == true ? turretMesh.material = _canPlaceMaterial : turretMesh.material = _cannotPlaceMaterial;
    }

}