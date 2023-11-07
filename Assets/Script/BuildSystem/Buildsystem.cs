using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Buildsystem : MonoBehaviour
{
    #region Singleton
    public static Buildsystem Instance;
    #endregion

    #region Variables
    private TurretController _currentTurret;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Grid _grid;
    [SerializeField] private Material _canPlaceMaterial, _cannotPlaceMaterial;

    private Material _normalMaterial;
    private bool _canPlace;

    public bool CanPlace { get => _canPlace; set => _canPlace = value; }
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    public void BeginSelect(TurretSO turretSO)
    {
        TurretController newTurret = Instantiate(turretSO.Prefab, transform).GetComponent<TurretController>();
        _currentTurret = newTurret;
        _normalMaterial = _currentTurret.GetComponent<MeshRenderer>().material;
    }

    public void DragSelect()
    {
        Vector3 mousePos = _inputManager.GetMousePos();
        Vector3Int gridPosition = _grid.WorldToCell(mousePos);
        _currentTurret.transform.position = new Vector3(_grid.CellToWorld(gridPosition).x, _currentTurret.transform.localScale.y / 2, _grid.CellToWorld(gridPosition).z);
    }

    public void EndSelect()
    {
        if (_canPlace)
        {
            _currentTurret.GetComponent<MeshRenderer>().material = _normalMaterial;
            CanPlaceturret(true);
        }
        else
        {
            CanPlaceturret(false);
            Destroy(_currentTurret.gameObject);
        }
    }


    public void CanPlaceturret(bool state)
    {
        _currentTurret.Placed = state;
    }

    public Material SetAvaibleMaterial(bool state)
    {
        CanPlace = state;
        MeshRenderer turretMesh = _currentTurret.GetComponent<MeshRenderer>();
        turretMesh.material = CanPlace == true ? turretMesh.material = _canPlaceMaterial : turretMesh.material = _cannotPlaceMaterial;
        return turretMesh.material;
    }

}